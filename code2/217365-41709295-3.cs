    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace DeepListCopy_testingSome
    {
        class Program
        {
            static void Main(string[] args)
            {
                List<int> list1 = new List<int>();
                List<int> list2 = new List<int>();
         
                //populate list1
                for (int i = 0; i < 20; i++)
                {
                    list1.Add(1);
                }
    
                ///////
                Console.WriteLine("\n int in each list1 element is:\n");
                ///////
    
                foreach (int i in list1)
                {
                    Console.WriteLine(" list1 elements: {0}", i);
                    list2.Add(1);
                }
    
                ///////
                Console.WriteLine("\n int in each list2 element is:\n");
                ///////
    
                foreach (int i in list2)
                {
                    Console.WriteLine(" list2 elements: {0}", i);
                }
    
                ///////enter code here
    
                for (int i = 0; i < list2.Count; i++)
                {
                    list2[i] = 2;
                }
    
    
    
                ///////
                Console.WriteLine("\n Printing list1 and list2 respectively to show\n"
                                + " there is two independent lists,i e, two differens"
                                + "\n memory locations after modifying list2\n\n");
                foreach (int i in list1)
                {
                    Console.WriteLine(" Printing list1 elements: {0}", i);
                }
    
                ///////
                Console.WriteLine("\n\n");
                ///////
    
                foreach (int i in list2)
                {
                    Console.WriteLine(" Printing list2 elements: {0}", i);
                }
    
                Console.ReadKey();
            }//end of Static void Main
        }//end of class
    }
