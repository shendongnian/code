      internal abstract class FildMap
      {
        public string ExactTargetFild { get; set; }
        public string DbFild { get; set; }     
        public abstract List<Attributes> GetAttributes(DataRow row);
      }
    
      internal class StringFildMap : FildMap
      {
        public string ExactTargetFild { get; set; }
        public string DbFild { get; set; }     
        public override List<Attributes> GetAttributes(DataRow row)
        {
          //string specific stuff
        }
      }
