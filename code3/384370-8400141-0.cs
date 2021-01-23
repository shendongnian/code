    public class TestData : IEquatable<TestData>
    {
       public string Name {get;set;}
       public string type {get;set;}
    
       public List<string> Members = new List<string>();
    
       public void AddMembers(string[] members)
       {
          Members.AddRange(members);
       }
       public bool Equals(TestData other)
       {
            if (this.Name != other.Name) return false;
            if (this.type != other.type) return false;
            
            // TODO: Compare Members and return false if not the same
            return true;
       }
    }
    if (testData1.Equals(testData2))
        // classes are the same
