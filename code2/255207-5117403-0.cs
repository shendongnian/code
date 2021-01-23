    for(int i=0; i < arr.Length; i+=500)
    {
        int len=500;
        if(arr.Length<i+500)
        {
            len=arr.Length;
        }
        ar.Add(arr.Substring(i,len));
    }
