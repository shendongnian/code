        /// <summary>
        /// Recursive get the MemberAssignment
        /// </summary>
        /// <param name="param">The initial paramter expression: var param =  Expression.Parameter(typeof(T), "item");</param>
        /// <param name="baseType">The type of the model that is being used</param>
        /// <param name="propEx">Can be equal to 'param' or when already started with the first property, use:  Expression.MakeMemberAccess(param, prop);</param>
        /// <param name="properties">The child properties, so not all the properties in the object, but the sub-properties of one property.</param>
        /// <param name="index">Index to start at</param>
        /// <returns></returns>
        public static MemberAssignment RecursiveSelectBindings(ParameterExpression param, Type baseType, Expression propEx, string[] properties, int index)
        {
            //Get the first property from the list.
            var prop = baseType.GetProperty(properties[index], BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.IgnoreCase);
            var leftProperty = prop;
            Expression selectPropEx = Expression.MakeMemberAccess(propEx, prop);
            //If this is the last property, then bind it and return that Member assignment
            if (properties.Length - 1 == index)
            {
                var memberAssignment = Expression.Bind(prop, selectPropEx);
                return memberAssignment;
            }
            //If we have more sub-properties, make sure the sub-properties are correctly generated.
            //Generate a "new Model() { }"
            NewExpression selectSubBody = Expression.New(leftProperty.PropertyType.GetConstructors()[0]);
            //Get the binding of the next property (recursive)
            var getBinding = RecursiveSelectBindings(param, prop.PropertyType, selectPropEx, properties, index + 1);
                
            MemberInitExpression selectSubMemberInit =
                Expression.MemberInit(selectSubBody, new List<MemberAssignment>() { getBinding });
            //Finish the binding by generating "new Model() { Property = item.Property.Property } 
            //During debugging the code, it will become clear what is what.
            MemberAssignment selectSubMemberAssignment = Expression.Bind(leftProperty, selectSubMemberInit);
            return selectSubMemberAssignment;
        }
