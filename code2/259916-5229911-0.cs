    public static void MySqlLink(string strConnection, string strCommand,
        object args, DataTable dtTable)
    {
        ....
            if (args != null)
            {
                foreach (PropertyInfo prop in args.GetType().GetProperties(
                    System.Reflection.BindingFlags.Public
                    | System.Reflection.BindingFlags.Instance))
                {
                    MyCommand.Parameters.AddWithValue("?" + prop.Name,
                        Convert.ToString(prop.GetValue(args, null)));
                }
            }
