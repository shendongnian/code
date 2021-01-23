    void SomeMethod(StringBuilder x)
    {
        x.Append("Modified");
    }
    ...
    StringBuilder builder = new StringBuilder();
    SomeMethod(builder);
    Console.WriteLine(builder.ToString()); // Writes "Modified"
