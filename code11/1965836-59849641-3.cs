    private ObservableCollection<Operation> operations= new ObservableCollection<Parent>();
    public ObservableCollection<Operation> Operations
      {
         get { return operations; }
         set
         {
            //Replace with your property changed code.
            //SetProperty(ref operations, value); 
         }
       }
    int moveId = 0;
    
    
    public ShellViewModel()
        {
    
            Operation operation1 = new Operation() { Id = moveId, Name = "Move1" };
            operation1.parameters.
            Add(new Parameters() { par0 = "J0", val0 = 2.34, par1 = "J1", val1 = 0.43 });
    
            moveId++;
    
            Operation operation2 = new Operation() { Id = moveId, Name = "Move2" };
            operation2.parameters.
            Add(new Parameters() { par0 = "J0", val0 = 5.32, par1 = "J1", val1 = 3.33 });
    
            Operations.Add(operation1);
            Operations.Add(operation2);
             moveId++;
        }
