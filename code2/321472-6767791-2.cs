    using System;
    public static class Program
    {
        [STAThread]
        private static void Main()
        {
            var myType = new MyType[3];
            myType[0] = new MyType();
            myType[1] = new MyType();
            myType[2] = new MyType();
            for (var i = 0; i < myType.Length; ++i)
            {
                myType[i].A = 0;
                myType[i].B = "1";
                myType[i].C = 2;
            }
            // alternatively, use foreach
            foreach (var item in myType)
            {
                item.A = 0;
                item.B = "1";
                item.C = 2;
            }
        }
    }
