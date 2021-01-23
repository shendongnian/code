    string TrixName = null;
    string Hardness = null;
    string Webpage = null;
    foreach (Control c in phdTrix.Controls)
    {
        if (c.GetType() == typeof(TextBox))
        {
            switch (c.ID)
            {
                case "TrixName":
                    TrixName = (c as TextBox).Text;
                    break;
                case "Hardness":
                    Hardness = (c as TextBox).Text;
                    break;
                case "Webpage":
                    Webpage = (c as TextBox).Text;
                    break;
            }
            UpdateTrix(TrixID, TrixName, Hardness, Webpage);
        }
    }
