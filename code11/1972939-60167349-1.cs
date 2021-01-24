using System;
using System.Collections.Generic;
namespace ClassRoom
{
    class person  
    {
        public int number { get; set; }
        public bool pass { get; set; }
        public person(int i, bool pass) //person constructor
        {
            number = i;
            this.pass = pass;
        }
    }
    class Program
    {
        public static void initializeClassroom(List<person> pList)
        {
            bool pass = false;
            for (int i = 1; i <= 10; i++)
            {
                pass = !pass;   //every other student passes
                pList.Add(new person(i, pass));
            }
        }
        public static void CheckForPass(List<person> pList)
        {
            foreach (person p in pList)
            {
                if (p.pass)
                {
                    Console.WriteLine("Congratulations! Member" + p.number + " passed");
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine("Member" + p.number + " did not pass");
                    Console.ReadKey();
                }
            }
        }
        static void Main(string[] args)
        {          
            List<person> pList = new List<person>();
            initializeClassroom(pList);
            CheckForPass(pList);
        }
    }      
}
This wolud be best if you created a container class to keep the students list, and the methods that access it.
  [1]: https://onlinegdb.com/Bkwj5-e7L
