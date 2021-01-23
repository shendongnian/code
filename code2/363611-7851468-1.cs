    public struct Complex: IComparable<Complex>
    {
       //complex rectangular number: a + bi
       public decimal A
       public decimal B
       //synonymous with absolute value, or in geometric terms, distance
       public decimal Modulus() { ... }
    
       //CompareTo() is the default comparison used by most built-in sorts;
       //all we have to do here is pass through to Decimal's IComparable implementation
       //via the results of the Modulus() methods
       public int CompareTo(Complex other){ return this.Modulus().CompareTo(other.Modulus()); }
          
    }
