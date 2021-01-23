    public class Document {
       private readonly List<DocumentSection> sections = new List<DocumentSection>();
    
       public IEnumerable<DocumentSection> Sections 
       { 
           get 
           { 
               lock (this.sections)
               {
                   return sections.ToList(); 
               }
           }
       }
    }
