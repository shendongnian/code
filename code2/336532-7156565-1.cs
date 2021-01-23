    public class ExtendedButton:Button
    {
        public ExtendedButton()
        {
            MouseEnter += (s, e) => Cursor = Cursors.Hand;
            MouseLeave += (s, e) => Cursor = Cursors.Arrow;
        }
    }
