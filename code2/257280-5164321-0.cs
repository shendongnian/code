    public AllViewModel()
    {
        var task = Task<List<Settings>>.Factory.StartNew(() =>
                         client.SupplierListWithSettings((s,e) => 
                         {
                             if (e.Error == null && e.Result != null)
                             {
                                 var list = new List<Settings>(); 
                                 foreach (VCareSupplierDto obj in e.Result)
                                 {
                                     list.Add(obj);
                                 }
                                 task.SetResult(list);
                             }
                         }));
        this.SettingsList = task.Result;
    }
