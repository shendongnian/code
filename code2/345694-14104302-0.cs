    //"Text" is the name of the Property which returns the value to validate
    [ValidationProperty("Text")] 
    public class InputTemplate
    {
        ...
        public string Text { set { txtValue.Text = value; } get { return txtValue.Text } }
    }
