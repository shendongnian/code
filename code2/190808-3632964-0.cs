    Type type = GetType();
    for (int i = 1; i <= 10; i++)
    {
        var name = "TB" + i;
        var field = type.GetField(name, BindingFlags.Instance | BindingFlags.NonPublic); //or appropriate flags
        TextBox tb = (TextBox)field.GetValue(this);
        //...
    }
