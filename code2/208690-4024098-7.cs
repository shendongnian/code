    public class Snippet
    {
        public string Name {get;set;}
        public char Char { get; set;}
        public string Value { get; set;}
    }   
    List<Snippet> Snippets = new List<Snippet>();
    XmlTextReader reader = new XmlTextReader ("snippets.xml");
   
    Snippet snippet = new Snippet();
    while (reader.Read()) 
    {
        // Do some work here on the data.
    	switch (reader.NodeType) 
        {
            case XmlNodeType.Element: 
             
            if(reader.Name == "snippet"){
                             
               while (reader.MoveToNextAttribute())
               {
                  if(reader.Name == "Name"){
                     // get name attribute value
                     snippet.Name = reader.Value;
                  }
                  else if(reader.Name == "Char"){
                     // get char attribute value
                     snippet.Char = Char.Parse(reader.Value);
                  }
                  
               } 
            } 
           
            break;
            case XmlNodeType.Text: //Display the text in each element.
               //Here we get the actual snippet code
               snippet.Value = reader.Value; 
            break;
            case XmlNodeType. EndElement:
                
                if(reader.Name == "snippet"){
                   // Add snippet to list
                   Snippets.Add(snippet);
                   // Create a new Snippet object
                   snippet = new Snippet();
                }
                 
            break;  
        }
    }
    
