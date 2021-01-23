    class Test
    {
        List<int> myList = new List<int>();
        public void TestMethod()
        {
            myList.Add(100);
            myList.Add(50);
            myList.Add(10);
            ChangeList();
            foreach (int i in myList)
            {
                Console.WriteLine(i);
            }
        }
        private void ChangeList()
        {
            myList.Sort();
            List<int> myList2 = new List<int>();
            myList2.Add(3);
            myList2.Add(4);
            myList = myList2;
        }
    }
 
    
