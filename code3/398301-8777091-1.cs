        Expression ParseNew() {
            NextToken();
			
			bool anonymous = true;
			Type class_type = null;
			
			if (token.id == TokenId.Identifier)
			{
				anonymous = false;
				StringBuilder full_type_name = new StringBuilder(GetIdentifier());
				
				NextToken();
				
				while (token.id == TokenId.Dot)
				{
					NextToken();
					ValidateToken(TokenId.Identifier, Res.IdentifierExpected);
					full_type_name.Append(".");
					full_type_name.Append(GetIdentifier());
					NextToken();
				}
				
				class_type = Type.GetType(full_type_name.ToString(), false);	
				if (class_type == null)
					throw ParseError(Res.TypeNotFound, full_type_name.ToString());
			}
				
            ValidateToken(TokenId.OpenParen, Res.OpenParenExpected);
            NextToken();
            List<DynamicProperty> properties = new List<DynamicProperty>();
            List<Expression> expressions = new List<Expression>();
            while (true) {
                int exprPos = token.pos;
                Expression expr = ParseExpression();
                string propName;
                if (TokenIdentifierIs("as")) {
                    NextToken();
                    propName = GetIdentifier();
                    NextToken();
                }
                else {
                    MemberExpression me = expr as MemberExpression;
                    if (me == null) throw ParseError(exprPos, Res.MissingAsClause);
                    propName = me.Member.Name;
                }
                expressions.Add(expr);
                properties.Add(new DynamicProperty(propName, expr.Type));
                if (token.id != TokenId.Comma) break;
                NextToken();
            }
            ValidateToken(TokenId.CloseParen, Res.CloseParenOrCommaExpected);
            NextToken();
			Type type = anonymous ? DynamicExpression.CreateClass(properties) : class_type; 
            MemberBinding[] bindings = new MemberBinding[properties.Count];
            for (int i = 0; i < bindings.Length; i++)
                bindings[i] = Expression.Bind(type.GetProperty(properties[i].Name), expressions[i]);
            return Expression.MemberInit(Expression.New(type), bindings);
        }
