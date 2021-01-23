        public static void ApplyIf(this ListItemCollection collection,
                              Action<ListItem> action, Func<ListItem, bool> predicate)
        {
            foreach (ListItem item in collection) 
            {
               if (predicate(item))
               {
                   action(item);
               }
            }
        }
