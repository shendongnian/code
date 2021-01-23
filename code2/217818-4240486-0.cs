    public class Test
    {
      public string Text { get; set; }
      public int Age { get; set; }
      
      public override GetHashCode()
      {
        int result = 
          string.IsNullOrEmpty(Text) ? 0 : Text.GetHashCode()
          + Age.GetHashCode();
          
        return result;
      }
    }
