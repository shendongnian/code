        public class myVM
        {
            public CollectionViewSource CollViewSource { get; set; }
            public string SearchFilter
            {
                get;
                set
                {
                  if(!string.IsNullOrEmpty(SearchFilter))
                     AddFilter();
                    CollViewSource.View.Refresh(); // important to refresh your View
                }
            }
            public myVM(YourCollection)
            {
                CollViewSource = new CollectionViewSource();//onload of your VM class
                CollViewSource.Source = YourCollection;//after ini YourCollection
            }
        }
