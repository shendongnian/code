    Console.WriteLine("Are two EquatableIntArrays equal? => " +
         EqualityComparer<EquatableIntArray>.Default.Equals(
             new EquatableIntArray(new int[] { 1 })
           , new EquatableIntArray(new int[] { 1 })));
     Console.WriteLine("Do two EquatableIntArrays have the same hashcode? => " +
          (new EquatableIntArray(new int[] { 1 }).GetHashCode()
        == new EquatableIntArray(new int[] { 1 }).GetHashCode()));
