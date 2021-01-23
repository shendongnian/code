    namespace MessageBoxExtensions
    {
        public static class MessageBoxExtensionsClass
        {
            public static void Foo(this MessageBox messageBox)
            {
                // ...
            }
        }
    }
    
    using MessageBoxExtensions;
    // ... 
    var messageBox = new MessageBox();
    messageBox.Foo();
