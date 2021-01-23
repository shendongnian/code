    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using System.Diagnostics;
    
    namespace ConsoleApplication1 {
    
        public static class ButtonChecker {
            public static bool IsPressed(int[] input) {
                return input[0] == 1;
            }
        }
        
        static class Program {
    
            public static void Main(){
                int[] Input = new int[6] { 1, 0, 2, 3,4 , 1 };
    
                for(int i = 0; i < Input.Length; ++i){
                    Console.WriteLine("{0} Is Pressed = {1}", i, ButtonChecker.IsPressed(Input));
                }
                Console.ReadKey();
            }
        }
    }
