    public List<RecipeDosings> resipeDosings = new List<RecipeDosings>();
    for (int i = 0; i < resipeDosings.Count; i++)
    {
        if (resipeDosings[i].Bunker.StartsWith("Bunker "))
        {
            modbus_master.SetValue("x1", Convert.ToInt32(resipeDosings[i].Massa) * 10, 1);      
        }
    }
