    public static List<T> Generate<T>()
    {
       byte[] data = Decrypt(MyWebService.GetData1());
       List<T> l = Deserialize<T>(data);   
       return l;
    }
