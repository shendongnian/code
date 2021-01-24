    public static class WindowExtensions
    {
        public static async Task<bool?> ShowDialogAsync(this Window window)
        {
            await Task.Yield(); // this is the magic ;o)
            return window.ShowDialog();
        }
    }
