        public static void ApplyUntil(this ListItemCollection collection,
                              Action<ListItem> action, Func<ListItem, bool> predicate)
        {
            foreach (ListItem item in collection) 
            {
               action(item);
               if (predicate(item))
               {
                   return;
               }
            }
        }
