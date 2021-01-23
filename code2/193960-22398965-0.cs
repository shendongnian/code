                int  [] n=new int[5];
                for (int i = 0; i < 5; i++)
                {
                    n[i] = i + 100;
                }
    
                foreach (int j in n)
                {
                    int i = j - 100;
                    Console.WriteLine("Element [{0}]={1}", i, j);
                    i++;
                }
