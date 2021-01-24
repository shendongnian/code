    public class MainWindowViewModel
    {
        public void OnMouseMove(object sender, MouseEventArgs e)
        {
            var point = e.GetPosition((IInputElement)e.Source);
        }
    }
