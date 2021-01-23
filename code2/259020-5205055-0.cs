    public static void Inverse<T>(IList<T> list) where T: IConvertible
    {
        for (int i = 0; i <= list.Count / 2; i++)
        {
            int a = Convert.ToInt16(list[i]); 
        }
    }
