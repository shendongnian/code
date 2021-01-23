    class Program
        {       
            private class SortIntDescending : IComparer<int>
            {
                int IComparer<int>.Compare(int a, int b) //implement Compare
                {              
                    if (a > b)
                        return -1; //normally greater than = 1
                    if (a < b)
                        return 1; // normally smaller than = -1
                    else
                        return 0; // equal
                }
            }
     
            static List<int> intlist = new List<int>(); // make a list
     
            static void Main(string[] args)
            {
                intlist.Add(5); //fill the list with 5 ints
                intlist.Add(3);
                intlist.Add(5);
                intlist.Add(15);
                intlist.Add(7);
     
                Console.WriteLine("Unsorted list :");
                Printlist(intlist);
     
                Console.WriteLine();
                // intlist.Sort(); uses the default Comparer, which is ascending
                intlist.Sort(new SortIntDescending()); //sort descending
     
                Console.WriteLine("Sorted descending list :");
                Printlist(intlist);
     
                Console.ReadKey(); //wait for keydown
            }
     
            static void Printlist(List<int> L)
            {
                foreach (int i in L) //print on the console
                {
                    Console.WriteLine(i);
                }
            }
        }
