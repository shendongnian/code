    int[] arr1 = { 37, 45, 65 };
            int[] arr2 = { 70, 89, 118 };
            
            var myList = new List<int>();
            myList.AddRange(arr1);
            myList.AddRange(arr2);
            int[] arr3 = myList.ToArray();
            Console.WriteLine("Combined array elements..");
            foreach (int res in arr3)
            {
                Console.Write(" " + res + " ");
            }
