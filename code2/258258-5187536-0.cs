    public class LinkLabelEx : LinkLabel
    {
        protected override void OnKeyUp(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                e.Handled = true;
                OnLinkClicked(new LinkLabelLinkClickedEventArgs(new Link(0, this.Text.Length)));
            }
            else
            {
                base.OnKeyUp(e);
            }
        }
    }
