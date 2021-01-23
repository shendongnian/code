    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Windows.Data;
    using WpfTreeViewBinding.Model;
    
    namespace WpfTreeViewBinding.ViewModels
    {
        public class ItemViewModel
        {
            private readonly ICollectionView _items;
    
            public ICollectionView Items
            {
                get { return _items; }
            }
    
            public ItemViewModel()
            {
                var itemProvider = new ItemProvider();
    
                IList<Item> items = itemProvider.GetItems("C:\\Temp");
    
                _items = CollectionViewSource.GetDefaultView(items);
            }
        }
    }
