    public class ComboBoxItem()
    {
       string displayValue;
       string hiddenValue;
   
       public ComboBoxItem (string d, string h)
       {
            displayValue = d;
            hiddenValue = h;
       }
    
       public override string ToString()
       {
            return displayValue;
       }
    }
