    public class MyButton : Button
    {
        private bool _buttonState;
    
        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);
    
            if (_buttonState)
            {
                BackColor = Color.Yellow;
            }
            else
            {
                BackColor = Color.White;
            }
        }
    }
