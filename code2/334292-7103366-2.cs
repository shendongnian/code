    public void MethodA(int[] i) { }
    // Get MethodA(int[] i)
    mInfo = typeof(Program).GetMethod("MethodA",
        BindingFlags.Public | BindingFlags.Instance,
        null,
        new Type[] { typeof(int[]) },
        null);
    Console.WriteLine("Found method: {0}", mInfo);
