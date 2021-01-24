    public static void Reset(this Mock mock)
    {
        mock.ConfiguredDefaultValues.Clear();
        mock.Setups.Clear();
        mock.EventHandlers.Clear();
        mock.Invocations.Clear();
    }
