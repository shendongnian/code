    public void Get_SumOf_first_and_last()
            {
                int temp;
    
                int j = Q.Count - 1;
    
                for (int i = 0; i <= j; i++)
                {
                    if (i == j)
                    {
                        Console.WriteLine(Q.ElementAt(j));
                    }
                    else
                    {
                        temp = Q.ElementAt(i) + Q.ElementAt(j);
                        j--;
                        Console.WriteLine(temp);
                    }
                }
            }
    
     static void Main(string[] args)
        {
            MyQueue test = new MyQueue();
            test.Add(5);
            test.Add(6);
            test.Add(2);
            test.Get_SumOf_first_and_last();
            //out put is
            //7
            //6
        }
