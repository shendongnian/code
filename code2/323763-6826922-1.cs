    DateTime dateValue;
    string dateString = textBox.Text;
    if (DateTime.TryParse(dateString, out dateValue)) 
    {
         // Use Date.CompareTo as you want to...
         
         int result = DateTime.Compare(dateValue, DateTime.Today);
         if (result > 0)
         {
              //Future Date 
         }
    }
