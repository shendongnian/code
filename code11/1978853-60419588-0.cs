    public class Point : IEquatable<Product>
    {
      public Point(int x, int y)
      {
        this.X = x;
        this.Y = y;
      }
    
      public int X { get; }
      public int Y { get; }
    
    
      public bool Equals(Point other)
      {
        //Check whether the compared object is null. 
        if (Object.ReferenceEquals(other, null)) return false;
    
        //Check whether the compared object references the same data. 
        if (Object.ReferenceEquals(this, other)) return true;
    
        //Check whether the products' properties are equal. 
        return X.Equals(other.X) && Y.Equals(other.Y);
      }
    
      // If Equals() returns true for a pair of objects  
      // then GetHashCode() must return the same value for these objects. 
    
      public override int GetHashCode()
      {
    
        //Get hash code for the Name field if it is not null. 
        int hashProductX = X == null ? 0 : X.GetHashCode();
    
        //Get hash code for the Code field. 
        int hashProductY = Y == null ? 0 : Y.GetHashCode();
    
        //Calculate the hash code for the product. 
        return hashProductX ^ hashY;
      }
    }
