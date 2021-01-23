    class Numbers : IEquatable<Numbers>
    {
      public int FirstNumber { get; set; }
      public int SecondNumber { get; set; }
      public int ThirdNumber { get; set; }
      
      public bool Equals(Numbers other)
      {
        if (other == null)
          return false;
        return (
          this.FirstNumber == other.FirstNumber &&
          this.SecondNumber == other.SecondNumber &&
          this.ThirdNumber == other.ThirdNumber
        );
      }
    }
