    using System.Linq;
    ...
    public Document searchByTitle (String aTitle) 
    {
      return this.FirstOrDefault(doc => doc.Title == aTitle);
    }
