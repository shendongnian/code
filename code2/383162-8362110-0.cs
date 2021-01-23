    #define USE_DOTNET
    //#define USE_SOMETHINGELSE
    #if USE_DOTNET
    using System.Drawing;
    #endif
    #if USE_SOMETHINGELSE
    using SomethingElse.Drawing;
    #endif
    public struct MyColor
    {
        #if USE_DOTNET
        Color TheColor;
        #endif
        #if USE_SOMETHINGELSE
        SomethingsColor TheColor;
        #endif
        public int R
        {
            get
            {
                #if USE_DOTNET
                    // code to return .NET Color.R value
                #endif
                #if USE_SOMETHINGELSE
                    // code to return SomethingColor.R value
                #endif
             }
        }
    }
