    class MyValue
    {
       // ...
       public override GetHashCode()
       {
          return this.Property1.GetHashCode();
          // if you want to compare more properties hash them all and use some function (for example ^)
          // to "add" the values
       }
    
       public override Equals(obj o)
       {
          if (ReferenceEquals(null, o)) return false;
          if (ReferenceEquals(this, o)) return true;
          if (o.GetType() != typeof (MyValue)) return false;
          var v2 = o as MyValue;
          return Equals(v2.Property1, this.Property1);
          // if you want to compare more than one property use && and Equals on them all
       }
    }
