    public class LabelEx : Label
    {
        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            if (Target != null)
            {
                Target.Focus();
            }
        }
    }
