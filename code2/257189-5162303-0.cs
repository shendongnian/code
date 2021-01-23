    switch(Type.GetType(effect.Options[0].ToString()))
    {
        case typeOf(System.Int32):
            int i = (System.Int32)effect.Options[0];
            break;
        case typeOf(System.Drawing.Color):
            System.Drawing.Color color = (System.Drawing.Color)effect.Options[0];
            break;
    }
