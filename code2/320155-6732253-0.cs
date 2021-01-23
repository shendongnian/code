    .class interface public abstract auto ansi System.Collections.IEnumerable
    {
      .custom instance void System.Runtime.InteropServices.ComVisibleAttribute::.ctor(bool) = ( 01 00 01 00 00 ) 
      .custom instance void System.Runtime.InteropServices.GuidAttribute::.ctor(string) = ( 01 00 24 34 39 36 42 30 41 42 45 2D 43 44 45 45   // ..$496B0ABE-CDEE
                                                                                            2D 31 31 64 33 2D 38 38 45 38 2D 30 30 39 30 32   // -11d3-88E8-00902
                                                                                            37 35 34 43 34 33 41 00 00 )                      // 754C43A..
    } // end of class System.Collections.IEnumerable
    .class interface public abstract auto ansi System.Collections.ICollection
           implements System.Collections.IEnumerable
    {
      .custom instance void System.Runtime.InteropServices.ComVisibleAttribute::.ctor(bool) = ( 01 00 01 00 00 ) 
    } // end of class System.Collections.ICollection
    .class interface public abstract auto ansi System.Collections.Generic.IEnumerable`1<+ T>
           implements System.Collections.IEnumerable
    {
      .custom instance void System.Runtime.CompilerServices.TypeDependencyAttribute::.ctor(string) = ( 01 00 14 53 79 73 74 65 6D 2E 53 5A 41 72 72 61   // ...System.SZArra
                                                                                                       79 48 65 6C 70 65 72 00 00 )                      // yHelper..
    } // end of class System.Collections.Generic.IEnumerable`1
    
    .class interface public abstract auto ansi System.Collections.Generic.ICollection`1<T>
           implements class System.Collections.Generic.IEnumerable`1<!T>,
                      System.Collections.IEnumerable
    {
      .custom instance void System.Runtime.CompilerServices.TypeDependencyAttribute::.ctor(string) = ( 01 00 14 53 79 73 74 65 6D 2E 53 5A 41 72 72 61   // ...System.SZArra
                                                                                                       79 48 65 6C 70 65 72 00 00 )                      // yHelper..
    } // end of class System.Collections.Generic.ICollection`1
