    using System;
    
    namespace primes
    { // program for find primes between 1 and n.
        class Program
        {    public  static void Main()
            {           
                int[] pr = new int[100], ct = new int[100];             
                ct[0] = 2;
                pr[0] = 3;// 3 is primes => n[0] is 3 . 
                int n = 1;
                int v = 0;
                for (int i = 5; i < 111; i += 2)
                {               
                    for (int l = 0; l < n; l++)
                    { if (ct[l] == 0)
                        {
                            ct[l] = pr[l] - 1;
                            v++;                                       
                        }
                        else
                        {
                            ct[l]--;                        
                        }                        
                    }    
                    if(v != 0)
                    { v = 0;
                    }
                   else  { 
                    pr[n] = i;
                    ct[n] = i-1 ;          
                    n++;
                }
        
                }
                for (int m = 0; m < n; m++)
                {
                    Console.Write(" {0}", pr[m]);
                }
                Console.ReadKey();            
            }
        }  
    }
