        static int n = 4;
        int[] baseArr = { 1, 2, 3, 4 };
        int[] LockNums;
        public void DoEx23()
        {
            int len = baseArr.Length;
            LockNums = new int[n];
            for (int i = 0; i < n; i++)
            {
                int num = baseArr[i];
                DoCombinations(num, baseArr, len);
                //for more than 4 numbers the print screen is too long if we need to check the result next line will help
                //Console.ReadLine(); 
            }
        }
        private void DoCombinations(int lockNum, int[] arr, int arrLen )        
        {
            int n1 = arr.Length;
            // next line shows the difference in length between the previous and its previous array
            int point = arrLen - n1; 
            LockNums[n - arr.Length] = lockNum;
            int[] tempArr = new int[arr.Length - 1];
            FillTempArr(lockNum, arr, tempArr);
            //next condition will print the last number from the current combination
            if (arr.Length == 1)
            {
                Console.Write(" {0}", lockNum);
                Console.WriteLine();
            }
            for (int i = 0; i < tempArr.Length; i++)
            {
                if ((point == 1) && (i != 0))
                {
                    //without this code the program will fail to print the leading number of the next combination
                    //and 'point' is the exact moment when this code has to be executed
                    PrintFirstNums(baseArr.Length - n1);
                }
                Console.Write(" {0}", lockNum);
                int num1 = tempArr[i];
                DoCombinations(num1, tempArr, n1);
            }
        }
        private void PrintFirstNums(int missNums)
        {
            for (int i = 0; i < missNums; i++)
            {
                Console.Write(" {0}", LockNums[i]);
            }
        }
        private void FillTempArr(int lockN, int[] arr, int[] tempArr)
        {
            int idx = 0;
            foreach (int number in arr)
            {
                if (number != lockN)
                {
                    tempArr[idx++] = number;
                }
            }
        }
        private void PrintResult(int[] arr)
        {
            foreach (int num in arr)
            {
                Console.Write(" {0}", num);
            }
        }
