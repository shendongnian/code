        public static LinkedPageElement<TElement> GetLinkedElement<TPage, TElement>(Page page, bool verbose = true) where TElement : class
        {
            var propInfos = page.GetType().GetProperties();
            // First try to find the property in the current page type
            foreach (var propInfo in propInfos)
            {
                var attributes = propInfo.GetCustomAttributes(typeof(LinkedPageAttribute), true);
                if (attributes.Length == 0) continue;
                var linkedPageAttribute = (from a in attributes where a.GetType() == typeof(LinkedPageAttribute) select a).FirstOrDefault();
                if (linkedPageAttribute == null || !(linkedPageAttribute is LinkedPageAttribute)) continue;
                if ((linkedPageAttribute as LinkedPageAttribute).PageType == typeof(TPage))
                {
                    return new LinkedPageElement<TElement>
                    {
                        Element = propInfo.GetValue(page, null) as TElement,
                        AutoClick = (linkedPageAttribute as LinkedPageAttribute).AutoClick
                    };
                }
            }
            // Then try to find it in a property
            var containedInProperty = propInfos.Where(x => x.PropertyType.IsSubclassOf(typeof(Page)))
                .Select(x => GetLinkedElement<TPage, TElement>((Page)x.GetValue(page, null), false))
                .FirstOrDefault(x => x != null);
            if (containedInProperty != null) return containedInProperty;
            // you are trying to navigate to a page which cannot be reached from the current page, check to see you have a link with LinkedPage attribute
            if (verbose)
                throw new ArgumentException("You don't have a link to this page {0} from this page {1}".FormatWith(typeof(TPage), page.GetType()));
            
            return null;
        }
