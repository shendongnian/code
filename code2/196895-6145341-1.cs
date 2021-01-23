        private static string ResolveEntitySet(Type type)
        {
            var entitySetAttribute =
                (EntitySetAttribute) type.GetCustomAttributes(typeof (EntitySetAttribute), true).FirstOrDefault();
            if (entitySetAttribute != null)
            {
                return entitySetAttribute.EntitySet;
            }
            return null;
        }
