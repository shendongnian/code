        //Sections relate to C# 4.0 spec
        class Test
        {
            readonly S readonlyS = new S();
    
            static void Main()
            {
                Test test = new Test();
                test.readonlyS.SetX();//valid we are incrementing the value of a copy of readonlyS.  This is per the rules defined in 7.6.4
                Console.WriteLine(test.readonlyS.x);//outputs 0 because readonlyS is a value not a variable
                //test.readonlyS.x = 0;//invalid
        
                using (S s = new S())
                {
                    s.SetX();//valid, changes the original value.  
                    Console.WriteLine(s.x);//Surprisingly...outputs 2.  Although S is supposed to be a readonly field...the behavior diverges.
                    //s.x = 0;//invalid
                }
            }
            
        }
    
        struct S : IDisposable
        {
            public int x;
    
            public void SetX()
            {
                x = 2;
            }
    
            public void Dispose()
            {
    
            }
        }    
