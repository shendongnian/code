        public static void CreateTree(string[] transportArray)
        {
            var root = TransportViewModels;
            foreach (var item in transportArray)
            {
                if (FindItem(item, root) == null)
                {
                    root.Add(new TransportViewModel() { Name = item, TransportItems = new ObservableCollection<TransportViewModel>() });
                    root = root.LastOrDefault().TransportItems;
                }
                else
                    root = FindItem(item, root).TransportItems;
            }
        }
        private static TransportViewModel FindItem(string item, ObservableCollection<TransportViewModel> root)
        {
            return  root.Where(e => e.Name == item)
                        .FirstOrDefault();
        }
