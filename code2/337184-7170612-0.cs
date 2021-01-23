    public class NonScrollingNumericUpDown : NumericUpDown
    {
        protected override void OnMouseWheel(MouseEventArgs e)
        {
               //Don't call base.OnMouseWheel(e)
        }
    }
