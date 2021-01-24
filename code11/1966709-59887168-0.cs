    class BaseData
    {
        BaseData(Dictionary<string,string> data)
        {
            this.CommonProp1 = data["CommonProp1"];
            this.CommonProp2 = data["CommonProp2"];
        }
    
        public string CommonProp1 { get; set; }
        public string CommonProp2 { get; set; }
    }
    
    class DataTypeA : BaseData
    {
        DataTypeA(Dictionary<string,string> data)
            : base(data) // <-- magic here
        {
            this.TypeA_Prop1 = data["TypeA_Prop1"];
            this.TypeA_Prop2 = data["TypeA_Prop2"];
        }
    
        public string TypeA_Prop1 { get; set; }
        public string TypeA_Prop2 { get; set; }
    }
