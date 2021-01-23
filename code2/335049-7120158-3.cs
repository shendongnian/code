    public static class XmlHelper {
    	public static IEnumerable<Book> StreamBooks(string uri) {
    		using (XmlReader reader = XmlReader.Create(uri)) {
    			string title = null;
    			string author = null;
    
    			reader.MoveToContent();
    			while (reader.Read()) {
    				if (reader.NodeType == XmlNodeType.Element
    					&& reader.Name == "Book") {
    					while (reader.Read()) {
    						if (reader.NodeType == XmlNodeType.Element &&
    							reader.Name == "Title") {
    							title = reader.ReadString();
    							break;
    						}
    					}
    					while (reader.Read()) {
    						if (reader.NodeType == XmlNodeType.Element &&
    							reader.Name == "Author") {
    							author =reader.ReadString();
    							break;
    						}
    					}
    					yield return new Book() {Title = title, Author = author};
    				}
    			}		
    		}
    	}
