    public class ContainableViewModel : BasicViewModel<ContainableModel>
    {
        public ContainableViewModel(ContainableModel model)
            : base(model)
        {
        }
    
        // you can now omit this method, it is defined on the abstract superclass
        //public ContainableModel Model { get { return ()Model; } }
    
        public int Children { get { return MyModel.Children; } set { MyModel.Children = value; } }
    }
    
    public class ContainableModel : ModelBase
    {
        public ContainableModel()
        {
            Children = 2;
        }
    
        public int Children { get; set; }
    }
