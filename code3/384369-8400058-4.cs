    public class TestData : IEquatable<TestData>
    {
       public string Name {get;set;}
       public string type {get;set;}
    
       public List<string> Members = new List<string>();
    
       public void AddMembers(string[] members)
       {
          Members.AddRange(members);
       }   
    
      // Overriding Equals member method, which will call the IEquatable implementation
      // if appropriate.
       public override bool Equals( Object obj )
       {
           var other = obj as TestData;
           if( other == null ) return false;
           return Equals (other);             
       }
       public override int GetHashCode()
       {
          // Provide own implementation
       }
       
       // This is the method that must be implemented to conform to the 
       // IEquatable contract
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
