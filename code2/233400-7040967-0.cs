     public void DistinctRootProjectionList<E>()
        {
            var classMapping = Context.Config.GetClassMapping(typeof(E));
            var propertyIterator = classMapping.UnjoinedPropertyIterator;
            List<IProjection> projections = new List<IProjection>();
            ProjectionList list = Projections.ProjectionList();
            list.Add(Projections.Property(classMapping.IdentifierProperty.Name), classMapping.IdentifierProperty.Name);
            foreach (var item in propertyIterator)
            {
                if (item.Value.IsSimpleValue || item.Value.Type.IsEntityType)
                {
                    list.Add(Projections.Property(item.Name), item.Name);
                }
            }
            query.UnderlyingCriteria.SetProjection(Projections.Distinct(list));
            query.TransformUsing(Transformers.AliasToBean<E>());
        }
