    interface IHasPosition
    {
        int Left { get; }
        int Top { get; }
    }
    
    internal class MyTemplate<WhatType> where WhatType : IHasPosition
    {
        internal static void Work( WhatType what )
        {
            int left = what.Left;
        }
    };
