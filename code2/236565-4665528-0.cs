    class MyForm : Form
    {
        IList<TextBox> _textBoxes = new List<TextBox>();
    
        private void AddTextBox(string categoryName){
            
            var myTextBox = new TextBox();
            myTextBox .Name = categoryName + "txtbx";
            // set other properties and add to Form.Controls collection
            _textBoxes.Add(myTextBox);
        }
        private TextBox FindTextBox(string categoryName)
        {
            return _textBoxes.Where( t => t.Name.StartsWith(categoryName)).FirstOrDefault();
        }
    }
