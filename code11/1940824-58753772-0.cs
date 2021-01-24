        class ScriptVariableMemberExpressionVisitorTemplateContext : TemplateContext
        {
            private readonly Action<ScriptVariableGlobal, ScriptVariableGlobal> memberExpressionVisitor;
            public ScriptVariableMemberExpressionVisitorTemplateContext(
                Action<ScriptVariableGlobal, ScriptVariableGlobal> memberExpressionVisitor)
            {
                this.memberExpressionVisitor = memberExpressionVisitor ??
                                               throw new ArgumentNullException(nameof(memberExpressionVisitor));
            }
            protected override object EvaluateImpl(ScriptNode scriptNode)
            {
                var memberExpression = scriptNode as Scriban.Syntax.ScriptMemberExpression;
                if (memberExpression != null
                    && memberExpression.Target is ScriptVariableGlobal
                    && memberExpression.Member is ScriptVariableGlobal)
                {
                    this.memberExpressionVisitor((ScriptVariableGlobal)memberExpression.Target, (ScriptVariableGlobal)memberExpression.Member);
                }
                return base.EvaluateImpl(scriptNode);
            }
        }
    ...
        var template = Template.Parse(@"
    <ul id='products'>
      {{ for product in products }}
        <li>
          <h2>{{ product.name }}</h2>
               Price: {{ product.price }}
               {{ product.description | string.truncate 15 }}
        </li>
      {{ end }}
    </ul>
    ");
    
        Dictionary<string, HashSet<string>> productFields = new Dictionary<string, HashSet<string>>();
        var context = new ScriptVariableMemberExpressionVisitorTemplateContext(
            (target, member) =>
            {
                if (!productFields.ContainsKey(target.Name))
                {
                    productFields[target.Name] = new HashSet<string>();
                }
                productFields[target.Name].Add(member.Name);
            });
    
        var scriptObject = new ScriptObject();
        scriptObject.Import(new { products = new[] { new { } } }); //required: `products` object from the template
        context.PushGlobal(scriptObject);
        template.Evaluate(context);
    
        productFields["product"].ToList().ForEach(Console.WriteLine); //show fields from product object, used by the template
