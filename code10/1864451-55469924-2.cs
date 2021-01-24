    public static class GlobalStaticClass
    {
        public static event FormClosedEventHandler FormClosed;
        public static void OnFormClosed(object sender, FormClosedEventArgs e)
        {
            FormClosed?.Invoke(sender, e);
        }
    }
