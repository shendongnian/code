        /// <summary>
        /// Returns entity set name for a given entity type
        /// </summary>
        /// <param name="context">An ObjectContext which defines the entity set for entityType. Must be non-null.</param>
        /// <param name="entityType">An entity type. Must be non-null and have an entity set defined in the context argument.</param>
        /// <exception cref="ArgumentException">If entityType is not an entity or has no entity set defined in context.</exception>
        /// <returns>String name of the entity set.</returns>
        internal static string GetEntitySetName(this ObjectContext context, Type entityType)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }
            if (entityType == null)
            {
                throw new ArgumentNullException("entityType");
            }
            // when POCO proxies are enabled, "entityType" may be a subtype of the mapped type.
            Type nonProxyEntityType = ObjectContext.GetObjectType(entityType);
            if (entityType == null)
            {
                throw new ArgumentException(
                    string.Format(System.Globalization.CultureInfo.CurrentUICulture,
                    Halfpipe.Resource.TypeIsNotAnEntity,
                    entityType.Name));
            }
            var container = context.MetadataWorkspace.GetEntityContainer(context.DefaultContainerName, System.Data.Metadata.Edm.DataSpace.CSpace);
            var result = (from entitySet in container.BaseEntitySets
                          where entitySet.ElementType.Name.Equals(nonProxyEntityType.Name)
                          select entitySet.Name).SingleOrDefault();
            if (string.IsNullOrEmpty(result))
            {
                throw new ArgumentException(
                    string.Format(System.Globalization.CultureInfo.CurrentUICulture,
                    Halfpipe.Resource.TypeIsNotAnEntity,
                    entityType.Name));
            }
            return result;
        }
