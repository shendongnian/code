    public class Snippet
    {
    	public string Name { get; set; }
    	public string Code { get; set; }
    	public char Character { get; set; }
    }
    XDocument doc = XDocument.Parse(@"<snippets>
    								  <snippet name='snippet1' character='a'> 
    									 <![CDATA[ 
    									   // Code goes here  
    									   ]]>
    								  </snippet>
    								  <snippet name='snippet2' character='b'> 
    									<![CDATA[ 
    									   // Code goes here
    										]]> 
    								  </snippet>
    								</snippets>");
    
    List<Snippet> snippetsList = (from snippets in doc.Descendants("snippet")
    							 select new Snippet
    							 {
    								 Name = snippets.Attribute("name").Value,
    								 Character = Convert.ToChar(snippets.Attribute("character").Value),
    								 Code = snippets.Value
    							 }).ToList();
    
    snippetsList.ForEach(s => Console.WriteLine(s.Code));
