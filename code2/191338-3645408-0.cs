    T[] rotate<T>(T[] a, int index)
    {
        T[] result = new T[a.Length];
        Array.Copy(a, index, result, 0, a.Length - index);
        Array.Copy(a, 0, result, a.Length - index, index);
        return result;
    }
    public void Run()
    {
        string[] words = { "The", "Quick", "Brown", "Fox", "Jumps" };
        string[] result = rotate(words, 2);
        foreach (string word in result)
        {
            Console.WriteLine(word);
        }
    }
