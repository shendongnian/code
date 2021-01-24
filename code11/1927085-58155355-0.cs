    class ProgressForm
    {
        private static ProgressForm staticRef;
        private void Form_Loaded(object sender, EventArgs e)
        {
            staticRef = this;
        }
        private void InternalCallback(uint m, IntPtr w, IntPtr l, IntPtr u)
        {
            // Ensure we're touching UI on the right thread
            if (Dispatcher.InvokeRequired)
            {
                Dispatcher.Invoke(() => InternalCallback(m, w, l, u));
                return;
            }
            // Update UI components
            // ....
        }
        private static uint StaticCallback(uint m, IntPtr w, IntPtr l, IntPtr u)
        {
            staticRef?.InternalCallback(m, w, l, u);
            return 0;
        }
    }
