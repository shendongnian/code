    private void Drink(object args)
    {
        string x = (string)args;
        if (x != null)
        {
            Tastes t = (Tastes)Enum.Parse(typeof(Tastes), x);
            if (t.HasFlag(Tastes.Sugar))
            {
                Console.WriteLine("sweet");
            }
        }
    }
