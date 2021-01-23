    public class DataGridWithUnhandledReturn : DataGrid
    {
        /// <inheritdoc/>
        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (e.Key == Key.Return && e.KeyboardDevice.Modifiers == ModifierKeys.None)
            {
                return;
            }
            base.OnKeyDown(e);
        }
    }
