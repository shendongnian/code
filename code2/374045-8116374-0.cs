    class Program
        {
            static void Main(string[] args)
            {
                List<int> mylist = new List<int>();
                mylist.Add(1);
                mylist.Add(1);
                mylist.Add(1);
                mylist.Add(1);
    
                bool allElementsAreEqual = mylist.All( x => ( x == mylist.First() ));
            }
        }
