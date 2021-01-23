    //css_ref Newtonsoft.Json.dll
    
    using System;
    using System.Windows.Forms;
    using Newtonsoft.Json;
    using System.Runtime.Serialization;
    
    public class StubData:StubBase {}
    
    public class StubBase {
        public string Id { get; set; }
    
        [OnDeserialized]
        public void OnDeserialized(StreamingContext context) {
            Id = "1";
        }
    }
    
    class Script
    {
    	[STAThread]
    	static public void Main(string[] args)
    	{
          var stubData = JsonConvert.DeserializeObject<StubData>(@"{""anyData"":""Foo""}");
          Console.WriteLine(stubData.Id); //returns 1
    	}
    }
