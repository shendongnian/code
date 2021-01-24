    void Main()
    {
    	var s = @"<mappings>
      <mapping>
        <a>a1value</a>
        <b>
          <c>
            <d>d1value</d>
            <e>e1value</e>
          </c>
        </b>
      </mapping>
      <mapping>
        <a>a2value</a>
        <b>
          <c>
            <d>d2value</d>
            <e>e2value</e>
          </c>
        </b>
      </mapping>
    </mappings>";
    	var data = from x in XDocument.Parse(s).Descendants("mapping")
    			   select new {
    			   	a=(string)x.Element("a"),
    				d=(string)x.Element("b").Element("c").Element("d")
    				};
    	
    	foreach (var e in data)
    	{
    		Console.WriteLine($"{e.a}, {e.d}");
    	}
    }
With a file, instead of `.Parse`, you would use `.Load( filename )`.
**Output**:
a1value, d1value
a2value, d2value
If you have a class matching this structure, like:
    public class MyData
    { 
    	public string A { get; set; }
    	public string D { get; set; }
    }
Then instead of the anonymous type you could use this class like so:
    var data = from x in XDocument.Parse(s).Descendants("mapping")
    		   select new MyData {
    		   	A=(string)x.Element("a"),
    			D=(string)x.Element("b").Element("c").Element("d")
    			};
    
    foreach (var e in data)
    {
    	Console.WriteLine($"{e.A}, {e.D}");
    }
PS: Since you are getting an IEnumerable, you could directly bind data to a `DataGridView, ListBox ... ( ...DataSource = data.ToList())`.
