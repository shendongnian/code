    #if true
    using MyService.X;
    using x=MyService.A;
    #endif
    #if false
    using MyService2.X;
    using x=MyService.B;
    #endif
