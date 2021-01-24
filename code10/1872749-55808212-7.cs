    public class PatchedListView : ListView
    {
        protected override void WndProc(ref Message m)
        {
            var suppress = m.Msg == 517 &&
                           Enum.TryParse(typeof(ListView).GetField("downButton", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(this).ToString(),
                                         out MouseButtons mouseButtons) &&
                           mouseButtons == MouseButtons.Right;
            if (suppress)
                return;
            base.WndProc(ref m);
        }
    }
