    public static System.Object GetItemByID(System.Type T, int UID)
    {
        IList mainList = GetAllItems().OfType<typeof(T)>();
        return mainList.Find(i => (int)(i.GetType().GetFields().Where(f => f.Name == "UID").FirstOrDefault().GetValue(i)) == UID);
    }
