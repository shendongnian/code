    override public Expression<Func<TParentEntity, bool>> 
            GetParentExpression<TParentEntity>( IDynamicQueryAdapter ctx ) 
        {
            // Define parameters needed in expresion tree
            ParameterExpression parentParameter = 
                Expression.Parameter (typeof (TParentEntity), "parent");
            ParameterExpression childParameter = 
                Expression.Parameter (typeof (TChildEntity), "child");
            // Define the IQueryable<TChildEntity> as 
            // a constant for use in the expression tree.
            IQueryable<TChildEntity> childDatasource = 
                ctx.GetQueryable<TChildEntity>().AsExpandable();
            ConstantExpression childDatasourceConstant = 
                Expression.Constant (childDatasource);
            // Get MethodInfo instance, needed for the MethodCallExpression
            MethodInfo anyMethodInfoChildEntity = 
                QueryHelper.GetQueryableAnyMethod<TChildEntity> ();
            
            // Get the lambda expression
            // required to select only those child entities
            // which meet the user defined criteria
            Expression<Func<TChildEntity, bool>> childSelectionExpression = 
                GetExpression<TChildEntity> (ctx);
            // Use the ExpressionParameter childParamter for the
            // ChildSelectionExpression and strip Expression.Invoke using Expand()
            Expression<Func<TChildEntity, bool>> lambda5 =
                Expression.Lambda<Func<TChildEntity, bool>> (
                Expression.Invoke (childSelectionExpression, childParameter),
                        childParameter).Expand ();
            #region Express the parent child relation
            PropertyInfo parentKeyPropertyInfo = null;
            PropertyInfo childKeyPropertyInfo = null;
            ctx.GetParentChildAssociationProperties (
                typeof (TParentEntity), typeof (TChildEntity),
                out parentKeyPropertyInfo, out childKeyPropertyInfo);
            Expression parentPropertyExpression =
                Expression.Property (parentParameter, parentKeyPropertyInfo.Name);
            Expression childPropertyExpression =
                Expression.Property (childParameter, childKeyPropertyInfo.Name);
            if( childKeyPropertyInfo.PropertyType != parentKeyPropertyInfo.PropertyType )
            {
                // TODO: what if the property types are incomparable >> exception.
                // some more code is needed!!
                Type nullableParentType = 
                    typeof (Nullable<>)
                    .MakeGenericType (parentKeyPropertyInfo.PropertyType);
                if( childKeyPropertyInfo.PropertyType == nullableParentType )
                {
                    childPropertyExpression =
                        Expression.Convert (childPropertyExpression,
                            parentKeyPropertyInfo.PropertyType);
                }
                else if( childKeyPropertyInfo.PropertyType.IsValueType )
                {
                    Type nullableChildType =
                        typeof (Nullable<>).MakeGenericType (childKeyPropertyInfo.PropertyType);
                    if( parentKeyPropertyInfo.PropertyType == nullableChildType )
                    {
                        parentPropertyExpression =
                            Expression.Convert (parentPropertyExpression,
                            childKeyPropertyInfo.PropertyType);
                    }
                }
            } 
            #endregion
            var lambda4 = Expression.Lambda<Func<TChildEntity, bool>> (
                Expression.Equal (
                    parentPropertyExpression, 
                    childPropertyExpression), childParameter );
            
            var predicate = lambda4.And(lambda5).Expand();
            Expression<Func<TParentEntity, bool>> parentSelectionExpression = 
                Expression.Lambda<Func<TParentEntity,bool>>(
                Expression.Call (
                    null, 
                    anyMethodInfoChildEntity, 
                    new Expression[] { childDatasourceConstant, predicate }),
                new[]{parentParameter});
            return parentSelectionExpression;
        }
