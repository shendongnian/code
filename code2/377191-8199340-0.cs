    public class CustomListBox : ListBox
    {
        public bool SelectionDisabled = false;
        protected override void OnMouseClick(MouseEventArgs e)
        {
            if (SelectionDisabled)
            {
                // do nothing.
            }
            else
            {
                //enable normal behavior
                base.OnMouseClick(e);
            }
        }
    }
