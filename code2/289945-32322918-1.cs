    public static class ExtMethods
    {
        public static void BringFormToFront(this Form form)
        {
            form.WindowState = FormWindowState.Normal;
            form.ShowInTaskbar = true;
            form.Show();
            form.Activate();
        }
    }
