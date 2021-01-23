    class MyClass
            {
            public int[] GetHour ()
                {
                DateTime dt = DateTime.Now;
    
                int hour = dt.Hour;
                int minute = dt.Minute;
    
                return new int[]{hour, minute};
                }
            }
    
    static void Main ( string[] args )
                {
                MyClass mc = new MyClass ();
    int[] temp = mc.GetHour();
                Console.WriteLine ("Hour: {0} \n Minute: {1}", temp[0], temp[1]);
    
                Console.ReadLine ();
                }
