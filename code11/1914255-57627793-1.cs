    IInterface src = new Child
    {
        CopyableProp = 42
    };
    IInterface dst = new Child();
    var copy = CreateCopyMethod(src.GetType()).Compile();
    copy(src, dst);
    Console.WriteLine(((Child)dst).CopyableProp); // 42
