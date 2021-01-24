    public class StateCityData {
      public string StateName { get; set; }
      public List<string> Cities { get; set; }
      public string ShortName { get; set; }
       
      public StateCityData () {
        StateName = "";
        Cities = new List<string>();
        ShortName = "";
      }
      public StateCityData(string state, string shortName) {
        StateName = state;
        Cities = new List<string>();
        ShortName = shortName;
      }
      public override bool Equals(object obj) {
        return obj is StateCityData data &&
               ShortName == data.ShortName;
      }
      public override int GetHashCode() {
        return -1319491066 + EqualityComparer<string>.Default.GetHashCode(ShortName);
      }
