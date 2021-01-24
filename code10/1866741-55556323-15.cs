    void Print(List<Student> list)
    {
        foreach(var item in list)
        {
            Console.WriteLine("{0}", item.Id);
        }
    }
    void Print(List<Admin> list)
    {
        foreach(var item in list)
        {
            Console.WriteLine("{0}", item.Name);
        }
    }
