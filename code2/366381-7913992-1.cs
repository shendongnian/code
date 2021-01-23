    public static void Close<T>(string formName) where T : MyForm
    {
        MyForm f = null;
        if (Dict.TryGetValue(formName, out f))
        {
            Dict.Remove(formName);
            f.InternalClose = true;
            f.Close();
            f.Dispose();
        }
    }
