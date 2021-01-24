    public static void Draw(Shapes s, Color c)
    {
        if (Mapper.TryGetValue(s,out var act))
        {
            act(c);
        }
     }
