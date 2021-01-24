     List<List<int>> MasterList = new List<List<int>>();
            List<int> childList1 = new List<int>() { 1, 2, 3 };
            List<int> childList2 = new List<int>() { 4, 5 };
            MasterList.Add(childList1);
           //  MasterList.Add(childList2);
            Console.WriteLine(MasterList.Contains(childList1));
            Console.WriteLine(MasterList.Contains(childList2));
            Console.WriteLine(MasterList[0].Contains(1));
            Console.WriteLine(MasterList[0].Contains(7));
    //True
    //False
    //True
    //False
