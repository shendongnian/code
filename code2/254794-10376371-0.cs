        private void SetStringPropertiesAsNonUnicode<e>(DbModelBuilder _modelBuilder) where e:class
        {
            //Indiquem a totes les propietats string que no són unicode per a que es crein com a varchar
            List<PropertyInfo> stringProperties = typeof(e).GetProperties().Where(c => c.PropertyType == typeof(string) && c.PropertyType.IsPublic).ToList();
            foreach (PropertyInfo propertyInfo in stringProperties)
            {
                dynamic propertyExpression = GetPropertyExpression(propertyInfo);
                _modelBuilder.Entity<e>().Property(propertyExpression).IsUnicode(false);
            }
        }
