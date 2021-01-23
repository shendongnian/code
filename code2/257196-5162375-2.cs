    for (int i = 0; i < effect.Options.Count; i++)
    {
        object oResult = Convert.ChangeType(effect.Options[i], Type.GetType(effect.Options[i].Attributes["Type"].Value.ToString()), CultureInfo.InvariantCulture);
        if (oResult is int)
        {
            //Process as int
            int iTmp = (int)oResult;
        }
        else if (oResult is Color)
        {
            //process as color
            Color cTmp = (Color)oResult;
        }
    }
