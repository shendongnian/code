    public static void FromWebClientRequest(int[] ids)
    {
        foreach (var id in ids)
        {
            Task.Factory.StartNew(i =>
            {
                Wl(i);
            }
            , id);
        }
    }
