    internal class MyTemplate<WhatType> where WhatType : ISomeInterface {
        internal static void Work( WhatType what )
        {
            int left = what.Left;
        }
    };
    interface ISomeInterface {
        int Left { get; }
    }
