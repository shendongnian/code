    <script runat="server">
    
    	public IEnumerable EvalIDNode(IEnumerable element, string idAttribute)
    	{
    		foreach (System.Xml.XmlElement node in element)
    		{
    			yield return new CustomNode(node, idAttribute);
    		}
    	}
    	
    	public class CustomNode : System.Xml.XPath.IXPathNavigable
    	{
    		private System.Xml.XmlElement _node;
    
    		public string IDField { get; private set; }
    
    		public CustomNode(System.Xml.XmlElement node, string idAttribute)
    		{
    			_node = node;
    			IDField = node.Attributes[idAttribute].Value;
    		}
    
    		public System.Xml.XPath.XPathNavigator CreateNavigator()
    		{
    			return _node.CreateNavigator();
    		}
    	}
    
    </script>
