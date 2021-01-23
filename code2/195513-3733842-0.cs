     static void TestA(A a)
     {
          Console.WriteLine("Test(a)");    
     }
     // Compilation error occurs if Test becomes:
     static void TestB(B a)
     {
          Console.WriteLine("Test(b)");
     }
     // this is valid because it's an exact match
     static CallBack callBackA = new CallBack(TestA);
     // this is valid because delegates support contravariance 
     static CallBack callBackB = new CallBack(TestB);
