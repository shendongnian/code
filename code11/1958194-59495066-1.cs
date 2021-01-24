      public class DItemViewModel
    {
        public ObservableCollection<DItem> lv { get; set; }
        public DItemViewModel()
        {
            DItem di = new DItem() { itemName = "someName", amt = 1, amtType = "xf" };
      
            lv = new ObservableCollection<DItem>();
            lv.Add(di);
        }
        
    }
