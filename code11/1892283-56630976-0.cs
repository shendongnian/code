    public class TextboxTrimSpacing : TextBox
    {
        private bool _trim = true;
        protected override void OnTextChanged(TextChangedEventArgs e)
        {
            base.OnTextChanged(e);
            if(_trim)
            {
                _trim = false;
                Text = Text?.Trim();
                _trim = true;
            }
        }
    }
