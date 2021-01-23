    // http://www.clariusconsulting.net/blogs/kzu/archive/2010/04/15/234739.aspx
    /// <summary>
    /// Validator provides helper methods to execute Data annotations validations
    /// </summary>
    public static class DataValidator
    {
        /// <summary>
        /// Checks if whole entity is valid
        /// </summary>
        /// <param name="entity">Validated entity.</param>
        /// <returns>Returns true if entity is valid.</returns>
        public static bool IsValid(object entity)
        {
            AssociateMetadataType(entity);
            var context = new ValidationContext(entity, null, null);
            return Validator.TryValidateObject(entity, context, null, true);
        }
        /// <summary>
        /// Validate whole entity
        /// </summary>
        /// <param name="entity">Validated entity.</param>
        /// <exception cref="ValidationException">The entity is not valid.</exception>
        public static void Validate(object entity)
        {
            AssociateMetadataType(entity);
            var context = new ValidationContext(entity, null, null);
            Validator.ValidateObject(entity, context, true);
        }
        /// <summary>
        /// Validate single property of the entity.
        /// </summary>
        /// <typeparam name="TEntity">Type of entity which contains validated property.</typeparam>
        /// <typeparam name="TProperty">Type of validated property.</typeparam>
        /// <param name="entity">Entity which contains validated property.</param>
        /// <param name="selector">Selector for property being validated.</param>
        /// <exception cref="ValidationException">The value of the property is not valid.</exception>
        public static void ValidateProperty<TEntity, TProperty>(TEntity entity, Expression<Func<TEntity, TProperty>> selector) where TEntity : class
        {
            if (selector.Body.NodeType != ExpressionType.MemberAccess)
            {
                throw new InvalidOperationException("Only member access selector is allowed in property validation");
            }
            AssociateMetadataType(entity);
            TProperty value = selector.Compile().Invoke(entity);
            string memberName = ((selector.Body as MemberExpression).Member as PropertyInfo).Name;
            var context = new ValidationContext(entity, null, null);
            context.MemberName = memberName;
            Validator.ValidateProperty(value, context);
        }
        /// <summary>
        /// Validate single property of the entity.
        /// </summary>
        /// <typeparam name="TEntity">Type of entity which contains validated property.</typeparam>
        /// <param name="entity">Entity which contains validated property.</param>
        /// <param name="memberName">Name of the property being validated.</param>
        /// <exception cref="InvalidOperationException">The entity does not contain property with provided name.</exception>
        /// <exception cref="ValidationException">The value of the property is not valid.</exception>
        public static void ValidateProperty<TEntity>(TEntity entity, string memberName) where TEntity : class
        {
            Type entityType = entity.GetType();
            PropertyInfo property = entityType.GetProperty(memberName);
            if (property == null)
            {
                throw new InvalidOperationException(String.Format(CultureInfo.InvariantCulture, 
                    "Entity does not contain property with the name {0}", memberName));
            }
            AssociateMetadataType(entity);
            var value = property.GetValue(entity, null);
            var context = new ValidationContext(entity, null, null);
            context.MemberName = memberName;
            Validator.ValidateProperty(value, context);
        }
        // http://buildstarted.com/2010/09/16/metadatatypeattribute-with-dataannotations-and-unit-testing/
        // Data Annotations defined by MetadataTypeAttribute are not included automatically. These definitions have to be injected.
        private static void AssociateMetadataType(object entity)
        {
            var entityType = entity.GetType();
            
            foreach(var attribute in entityType.GetCustomAttributes(typeof(MetadataTypeAttribute), true).Cast<MetadataTypeAttribute>())
            {
                TypeDescriptor.AddProviderTransparent(
                    new AssociatedMetadataTypeTypeDescriptionProvider(entityType, attribute.MetadataClassType), entityType);
            }
        }
    }
