    public class MyClass
    { 
         public int Id; 
         public int Id2;
         public int Id3;
		 public object[] GetPKs() => new object[] { Id, Id2 };
         public IEnumerable<string> GetPNames() 
		 {
		 	var allProperties = GetType().GetProperties().Select(x=>new {x.Name, Value = x.GetValue(this)});
			var allFields = GetType().GetFields().Select(x=>new {x.Name, Value = x.GetValue(this)});
			var dict = allProperties.Concat(allFields).ToDictionary(x=>x.Value, x=>x.Name);
		 	foreach(var value in GetPKs())
			{
				yield return dict[value];
			}
		 }
    }
