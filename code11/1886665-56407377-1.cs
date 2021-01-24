    bool flag = false ;
    
    for (int i = 0; i < arr.Length; i++)
    {
        if (arr[i].GetSomeValue() >= 1 && arr[i].GetSomeValue() <= 5)
        {
            Console.WriteLine(arr[i]);
            flag=true;
        }
    }
    if(!flag)
    {
        Console.WriteLine("No data");
    }
