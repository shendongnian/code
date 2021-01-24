      public class StudentComparerByName : IEqualityComparer<Student>
      {
        public bool Equals(Student x, Student y)
        {
          if (x == null && y == null) 
          {
            return true;
          }
    
          if (x == null || y == null)
          {
            return false;
          }
    
          return string.Equals(x.Name, y.Name);
        }
    
        public int GetHashCode(Student obj)
        {
          if (obj == null)
            throw new ArgumentNullException(nameof(obj));
    
          return obj.Name?.GetHashCode() ?? 0;
        }
      }
