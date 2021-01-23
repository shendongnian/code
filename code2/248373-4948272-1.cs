            Byte[] myByte = { 1, 2, 3, 4, 4, 2, 3, 4, 2, 5, 3, 4, 4, 2, 6, 3, 4, 5, 3, 3 };
            IList<Byte[]> myList = myByte.GroupArray(5);
            foreach (var item in myList)
            {
                Console.Write(item + " ");
                foreach (var item2 in item)
                {
                    Console.Write(item2);
                }
                Console.WriteLine();
            }
