    internal class MyTemplate<WhatType> {
        internal static void Work( WhatType what )
        {
            int left = ((dynamic)what).Left;
        }
    };
