    public class DragTextBox : TextBox
    {
        private string dragText;
        private const int WM_LBUTTONDOWN = 0x201;
        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (dragText.Length > 0)
            {
                SelectionStart = Text.IndexOf(dragText);
                SelectionLength = dragText.Length;
                DoDragDrop(dragText, DragDropEffects.Copy);
                SelectionLength = 0;
            }
            base.OnMouseDown(e);
        }
        protected override void WndProc(ref Message m)
        {
            if ((m.Msg == WM_LBUTTONDOWN))
                dragText = SelectedText;
            base.WndProc(ref m);
        }
    }
