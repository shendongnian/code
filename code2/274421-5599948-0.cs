    public class MyDomainModel
    {
        public bool BoolValue { get; set; }
    
        public string Prop1 { get; set; }
        public int Prop2 { get; set; }
    
        public MyDomainModel(MyDomainModel myDomainModel)
        {
            var myViewModel = new MyViewModel();
    
            //*****
            this.BoolValue = myDomainModel.BoolValue;
            this.Prop1 = myDomainModel.Prop1;
            this.Prop2 = myDomainModel.Prop2;
            // Several other properties
            //*****
        }
    }
    
    public class MyViewModel : MyDomainModel
    {
        // This is the only property that is added to the view model class
        public string DisplayValue
        {
            get { return BoolValue ? "Value1" : "Value2"; }
        }
    }
