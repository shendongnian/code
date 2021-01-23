    DateTime dateValue;
    string dateString = textBox.Text;
    if (DateTime.TryParse(dateString, out dateValue)) 
    {
         // Use Date.CompareTo as you want to...
         dateValue.[Date.CompareTo][1](DateTime.Today);
    }
