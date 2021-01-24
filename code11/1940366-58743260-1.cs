    public class collectionviewmodel:ViewModelBase
    {
        public ObservableCollection<Model> Items { get; set; }
       
        public collectionviewmodel()
        {
            Items = new ObservableCollection<Model>();
            Items.Add(new Model() { DisplayName = "AAA", Selected = false });
            Items.Add(new Model() { DisplayName = "BBB", Selected = false });
            Items.Add(new Model() { DisplayName = "CCC", Selected = false });
            Items.Add(new Model() { DisplayName = "DDD", Selected = false });
            Items.Add(new Model() { DisplayName = "EEE", Selected = false });
                                
        }       
    }
