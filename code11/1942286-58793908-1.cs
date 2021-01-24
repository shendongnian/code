    public static void Main( string[] args ) {
      var array1 = new double[10] { 0, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
      var array2 = new double[5] { 0, 1, 2, 3, 4 };
      var multiplication = Multiply( array1, array2 );
      foreach ( var item in multiplication ) {
        Console.WriteLine( item );
      }
      Console.ReadLine();
    }
