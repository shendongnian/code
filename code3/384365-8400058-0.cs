    public class TestData : IEquatable<TestData>
    {
       public string Name {get;set;}
       public string type {get;set;}
    
       public List<string> Members = new List<string>();
    
       public void AddMembers(string[] members)
       {
          Members.AddRange(members);
       }   
    
       public bool Equals( TestData other )
       {
           if( other == null )
           {
                return false;
           }
    
           if( ReferenceEquals (this, other) )
           {
                return true;
           }
    
           // You can also use a specific StringComparer instead of EqualityComparer<string>
           // Check out the specific implementations (StringComparer.CurrentCulture, e.a.).
           if( EqualityComparer<string>.Default.Compare (Name, other.Name) == false )
           {
               return false;
           }
           ...
    
           // To compare the members array, you could perhaps use the 
           // [SequenceEquals][2] method.  But, be aware that [] {"a", "b"} will not
           // be considerd equal as [] {"b", "a"}
           return true;
    
       }
    
    }
