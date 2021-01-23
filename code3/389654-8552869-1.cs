    void Main()
    {
    	XmlDynamicModel x = new XmlDynamicModel(@"path/myobject.xml");
        //you're element should be <description>value</description>
        //I would rather capitalize the first letter **Description
    	Console.WriteLine(x.TheObject.description);
    	Console.WriteLine(x.TheObject.name);
    }
    public class XmlDynamicModel
    {
        public XmlDynamicModel(string xmlfile)
    	{
    	  this.TheObject = new ExpandoObject();
    	  var t = this.TheObject as IDictionary<String, object>;
    	  XDocument xmlDoc = XDocument.Load(xmlfile);
          //get all objects UNDER product
    	  foreach(var elem in xmlDoc.Descendants().Descendants())
    	  {
    	    t[elem.Name.ToString()] = elem.Value.ToString();
    	  }
    	}
    	public dynamic TheObject {get;set;}
    }
