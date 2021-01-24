    public void CreateRandomPassword()
    {
        while(true)
        {
            string pass = CrearPassword(8, "user");
            if(ValidPassword(pass, "user"))
            {
                break;
            }
        }
    }
