    class MyBindingList<T> : BindingList<T>
    {
        ...
        protected override void ApplySortCore(PropertyDescriptor prop,
                                              ListSortDirection direction)
        {
            if (prop.PropertyType.Equals(typeof(Image)))
            {
                _SortPropertyCore = prop;
                _SortDirectionCore = direction;
                var items = this.Items;
                Func<T, object> func =
                    new Func<T, object>(t => (prop.GetValue(t) as Image).Tag);
                switch (direction)
                {
                    case ListSortDirection.Ascending:
                        items = items.OrderBy(func).ToList();
                        break;
                    case ListSortDirection.Descending:
                        items = items.OrderByDescending(func).ToList();
                        break;
                }
                ResetItems(items as List<T>);
                ResetBindings();
            }
            else
            {
                ...
            }
        }
        private void ResetItems(List<T> items)
        {
            base.ClearItems();
            for (int itemIndex = 0; itemIndex < items.Count; itemIndex++)
            {
                base.InsertItem(itemIndex, items[itemIndex]);
            }
        }
    }
