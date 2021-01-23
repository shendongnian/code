    if(Type.GetType(effect.Options[0].ToString()) == "System.Int32")
    {
        int i = (System.Int32)effect.Options[0];
    }
    else if(Type.GetType(effect.Options[0].ToString()) == "System.Drawing.Color")
    {
        System.Drawing.Color color = (System.Drawing.Color)effect.Options[0];
    }
