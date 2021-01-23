    public class MyComparer : IEqualityComparer<string[]>
    {
      public bool Equals(string[] a, string[] b)
      {
        if (a.Length != b.Length ) return false;
        for (int i  = 0; i < a.Length;i++)
        {
           if (a[i] != b[i])
             return false;
        }
       
        return true;
      }
 
     public int GetHashCode(string[] a)
      {
        return a.GetHashCode();
      }
    }
