    public class MyComparer : IEqualityComparer<KeyValuePair<string,string>> {
    	public bool Equals(KeyValuePair<string, string> x, KeyValuePair<string, string> y) {
    		return x.Key.Equals(y.Key);
    	}
    
    	public int GetHashCode(KeyValuePair<string, string> obj) {
    		return obj.Key.GetHashCode();
    	}
    }
    
    ...
    
    Dictionary<string, string> d1 = new Dictionary<string, string>();
    d1.Add("A", "B");
    d1.Add("C", "D");
    
    Dictionary<string, string> d2 = new Dictionary<string, string>();
    d2.Add("E", "F");
    d2.Add("A", "D");
    d2.Add("G", "H");
    
    MyComparer comparer = new MyComparer();
    
    var d3 = d1.Concat(d2.Except(d1, comparer));
    foreach (var a in d3) {
    	Console.WriteLine("{0}: {1}", a.Key, a.Value);
    }
