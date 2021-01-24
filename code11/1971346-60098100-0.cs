    interface IViewer {
        string Name {get;set;}
    }
    
    class LandViewer: IViewer {
        public string Name {get;set;}
        public int SomeValue;
    }
    class SeaViewer: IViewer {
        public string Name {get;set;}
        public string SomeOtherValue;
    }
    
    public override SetInsurance(IViewer viewer, DataTable patient, int InsurancePriority) {
        Console.WriteLine(viewer.Name); //.Name is accessible as it's part of the 95%
        
        // .SomeValue and .SomeOtherValue are not accessible, because they're not part of the 95% 
    }
