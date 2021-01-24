    [Flags]
    public enum tag
    {
        tag0 = 1,
        tag1 = 2,
        tag2 = 4,
        tag3 = 8,
        tag4 = 16
    }
    
    
    public class Trait
    {
        ...
        public tag Tags:
        ...
    }
    
    var trait = new Trait { Tags = tag.tag0 | tag.tag1 };
        
    if ((trait.Tags & tag.tag2) == tag.tag2)
    {
          // use & to check if tag exists
          Console.WriteLine("Has tag2");
    }
    else
    {
         Console.WriteLine("Does not have tag2");
    }
        
    trait.Tags = trait.Tags | tag.tag2;   // use | to add
       
        
    if ((trait.Tags & tag.tag2) == tag.tag2)
    {
          // use & to check if tag exists
          Console.WriteLine("Has tag2");
    }
    else
    {
         Console.WriteLine("Does not have tag2");
    }
