        public static LinkedPageElement<T> GetLinkedElement<T>(Page page) 
            where T : class
        {
            var propInfos = page.GetType().GetProperties(); 
            foreach (var propInfo in propInfos)
            {
                if( !propInfo.PropertyType == typeof(T) ) 
                {
                    // Check the property is the right type
                    continue;
                }
                var attributes = propInfo.GetCustomAttributes(typeof(LinkedPageAttribute), true);
                if (attributes.Length == 0) 
                    continue;
                LinkedPageAttribute linkedPageAttribute = attributes.OfType<LinkedPageAttribute>().FirstOrDefault();
                if (linkedPageAttribute == null) 
                    continue;
                if (linkedPageAttribute.PageType == typeof(TPage))
                {
                    return new LinkedPageElement<T>
                    {
                        Element = propInfo.GetValue(page, null) as T,
                        AutoClick = linkedPageAttribute.AutoClick
                    };
                }
            }
            // not found, check children
            foreach (var propInfo in propInfos)
            {
                if( !propInfo.PropertyType.IsAssignableFrom(Page) ) 
                {
                    // Check the property is a sub-page
                    continue;
                }
                // Get the sub page value
                Page subPage = propInfo.GetValue(page, null) as Page,
                // Recursively call this method
                var subAttribute = GetLinkedElement<T>(subPage);
                
                // If that's found the attribute return it
                if(subAttribute != null)
                {
                    return subAttribute;
                }
            }
            // throw your exception somewhere above
            return null;
        }
