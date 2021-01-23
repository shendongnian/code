    public class CommonFeatures<T> where T : TextBoxBase
    {
        private T innerTextBox;
        protected CommonFeatures<T>(T inner)
        {
            innerTextBox = inner;
            innerTextBox.TextChanged += OnTextChanged;
        }
        public T InnerTextBox { get { return innerTextBox; } }
        protected virtual void OnTextChanged(object sender, TextChangedEventArgs e) 
        { 
            ... do your stuff            
        }
    }
