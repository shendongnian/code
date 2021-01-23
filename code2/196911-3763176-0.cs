     public delegate void Test(int a, int b = 0);
     static void T1(int a, int b) { }
     static void T2(int a, int b = 0) { }
     static void T3(int a) { }
        Test t1 = T1;
        Test t2 = T2;
        Test t3 = T3;   // Error
