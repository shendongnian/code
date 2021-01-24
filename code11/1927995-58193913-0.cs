    public class someFoo
    {
    int Identifier {get; set;}
    someType someBar {get; set;}
    }
    List<someFoo> yourList = new List<someFoo>();
    
    // fill your list here.
    
    someFoo specifiedFoo = yourList.Where(i=> i.Identifier == X).FirstOrDefault(); 
    // x = your id  
    // you also need to import Linq.
    
    specifiedFoo.someBar = yourBar; // set it with your bar.
