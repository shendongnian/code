    private List<MyObject> objects = new List<MyObject>();
    public ObservableCollection<String> Groups
    {
      get
      {  
         ObservableCollection<String> temp = new ObservableCollection<String>();
         foreach (MyObject mo in objects)
         {
           if (!temp.Contains(mo.category))
             temp.Add(mo.category)
         }
         return temp;
      }
      set
      {
         objects = value;
         RaisePropertyChanged("Groups");
      }
    }
