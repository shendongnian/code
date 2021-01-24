    #if NETSTANDARD1_6
         public const IsCore = true;
    #elif NETSTANDARD1_5
         public const IsCore = true;
    #elif NETSTANDARD1_4
         public const IsCore = true;
    #elif NETSTANDARD1_3
         public const IsCore = true;
    #elif NETSTANDARD1_2
         public const IsCore = true;
    #elif NETSTANDARD1_1
         public const IsCore = true;
    #elif NETSTANDARD1_0
         public const IsCore = true;
    #else
         public const IsCore = false;
    #endif
