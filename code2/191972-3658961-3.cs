    void Main()
    {
     //- Load a caseConductor 
     var caseConductor = new CaseConductor(); 
     caseConductor.CaseID = "A00001";  
     // person  
     caseConductor.Person = new Person(); 
     caseConductor.Person.Surname = "Smith" ; 
     caseConductor.Person.DOB = DateTime.Now ;  
     // case note list 
     caseConductor.CaseNoteList = new List<Note>(); 
     caseConductor.CaseNoteList.Add(new Note { NoteText = "A-1" , NoteDt  = DateTime.Now }); 
     caseConductor.CaseNoteList.Add(new Note { NoteText = "B-2", NoteDt = DateTime.Now }); 
     // I could do this ... 
     string val1 = caseConductor.GetPropertyValue<string>("Person.Surname"); 
     // or this ... 
     Note val2 =  caseConductor.GetPropertyValue<Note>("CaseNoteList^1"); 
     val1.Dump("val1"); //this is a string
     val2.Dump("val2"); //this is a Note
    }
    
    public static class extensions
    {
     public static T GetPropertyValue<T>(this object o,string Properties) where T:class
     {
    
      var properties = Properties.Split('.');
      var indexsplit = properties[0].Split('^');
      
      var current = indexsplit[0];
     
    
      var prop = (from p  in o.GetType().GetProperties() where p.Name == current select p).Take(1).Single();
      var val = prop.GetValue(o,null);
      
      if(indexsplit.Length>1)
      {
       var index = int.Parse(indexsplit[1]);
       IList ival = (IList)val;
       val = ival[index];
      }
      
      if(properties[0] == Properties)
       return (T)val;
      else
       return val.GetPropertyValue<T>(Properties.Replace(properties[0]+".",""));
     }
    }
    
    
    class Note 
     { 
      public Guid NoteID { get; set; } 
      public string NoteText { get; set; } 
      public DateTime? NoteDt { get; set; } 
     } 
     public class Person 
     { 
      public Guid PersonID { get; set; } 
      public string Surname { get; set; } 
      public string Forename { get; set; } 
      public DateTime? DOB { get; set; } 
     } 
     class CaseConductor 
     { 
      public String CaseID{get;set;} 
      public Person Person { get; set; } 
      public List<Note> CaseNoteList { get; set; } 
     } 
        
