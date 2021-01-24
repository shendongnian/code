      [DataContract]
       public class DataPoint
       {
          public DataPoint(string x, double y,string innerval,string outerval)
          {
            this.label = x;
            this.y = y;
            this.innerValue = innerval;
            this.outerValue = outerval;
           
         
           // this.X = x;
        }
        [DataMember(Name = "label")]
        public string label { get; set; }
        //Explicitly setting the name to be used while serializing to JSON.
        [DataMember(Name = "y")]
        public Nullable<double> y = null;
        [DataMember(Name = "outerValue")]
        public string outerValue { get; set; }
        [DataMember(Name = "innerValue")]
        public string innerValue { get; set; }
    }
