    namespace System.Windows.Forms
    {
        public static class MyCustomMessageBox
        {
            public static void Foo()
            {
                MessageBox.Show("MyText");
            }
        }
    }
    MyCustomMessageBox.Foo();
