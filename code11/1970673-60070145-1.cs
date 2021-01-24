    public class MyObject
    {
        // "defining" attributes
        public List<string> DefiningAttributes { get; set; }
        // other attributes
        public List<string> OtherAttributes { get; set; }
    
        public MyObject()
        {
            //I used constructor to assign values
            DefiningAttributes = new List<string>() { "ABC",  "PQR",  "XYZ" };
            OtherAttributes = new List<string>() { "ABC",  "PQR",  "Stackoverflow" };
        }
        public bool compare(MyObject that)
        {
             var difference = this.DefiningAttributes.Except(that.DefiningAttributes);
             //Return false If they are all different between two objects OR if they are all same
             if(difference.Count() == this.DefiningAttributes.Count() || !difference.Any())
                    return false;
              //Otherwise return true
              return true;
        }
    }
