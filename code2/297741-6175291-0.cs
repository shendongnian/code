    class MyDllClass
    {
        [DllExport]
        static int MyDllMethod(int i)
        {
            MessageBox.Show("The number is " + i.ToString());
            return i + 2;
        }
    }
