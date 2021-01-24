    public static Stack<T> newStack<T>(int length)
    {
        Stack<T> s = new Stack<T>();
        for (int i = 0; i < length; i++)
        {
            Console.WriteLine("print num");
            string input = Console.ReadLine();
            T value = (T)Convert.ChangeType(input, typeof(T));
            s.Push(value);
        }
        return s;
    }
    
    public static Stack<int> newStack(int length)
    {
        // Call our original new stack method but pass
        // integer as the type T
        return newStack<int>(length);
    }
