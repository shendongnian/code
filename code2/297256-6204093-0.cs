        public class Test
        {
          public string Name { get; set; }
          public DateTime DateReported { get; set; }
    
          public override bool Equals(object obj)
          {
            Test test = obj as Test;
            if (test == null )
              return false;
            return string.Equals(this.Name, test.Name) && this.DateReported == test.DateReported; 
          }
  
          public override int GetHashCode()
          {
            return Name.GetHashCode() ^ DateReported.GetHashCode();
          }
        }
