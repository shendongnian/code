    public static Test Callme(int GetVal)
    {
        Test obj = new Test(GetVal);
        Console.WriteLine(obj.val);
        return obj;
    }
