    static class MainFormExtensions
    {
        public static void BindData(this MainForm form, object value)
        {
            //Whichever implementation you prefer, E.G.
            MainForm.BindData(value as Document);
        }
    }
