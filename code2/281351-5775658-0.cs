    using System.Windows.Forms;
    namespace MyApplication
    {
        class MyClass
        {
            void Go()
            {
                var previousPosition = Cursor.Position;
    
                // Do smth
    
                Cursor.Position = previousPosition;
            }
        }
    }
