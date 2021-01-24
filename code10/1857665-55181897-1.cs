    ObservableCollection<string> Modules = new ObservableCollection<string>();
    public MainWindow()
    { 
          //Assign item source only once and try adding items it should help
          lbxTimeTable.ItemsSource = Modules;
    }  
    public void PassedThroughWindow(string _module)
    {
        string moduleName = _module;
        //Data not being printed to the listbox
        //Change stringModules to Modules which is defined above
        Modules.Add(moduleName.ToString());
        
    }
