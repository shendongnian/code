    		public static void Test()
    		{
    			var xdoc = XDocument.Parse(@"
    <Snippets>
      <Snippet name='abc'>
        <SnippetCode>
          testcode1
        </SnippetCode>
      </Snippet>
    
      <Snippet name='xyz'>
        <SnippetCode>      
         testcode2
        </SnippetCode>
      </Snippet>
    
    </Snippets>");
    
    			xdoc.Root.Add(
    				new XElement("Snippet",
    					new XAttribute("name", "name goes here"),
    					new XElement("SnippetCode", "SnippetCode"))
    				);
    			xdoc.Save(@"C:\TEMP\FOO.XML");
    		}
