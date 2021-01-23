    public class FormSaving
            {
                ...
             
                public int Startzbuildfrom
                {
                    get;
    
                    set;
                }
    
    
            }
    ...
    abc.Startzbuildfrom = StartzbuildfromcomboBox.SelectedIndex;
    
    ...
    StartzbuildfromcomboBox.SelectedIndex = abc.Startzbuildfrom;
