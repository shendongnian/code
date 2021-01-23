            try
            {
                // Your code
            }
            catch (Exception ex)
            {
                switch (ex.Message)
                {
                    case "Some system exception information":                       
                        MessageBox.Show("Your text to replace system exception information",
                         "Warning",
                         MessageBoxButtons.OK, MessageBoxIcon.Warning);  
                        break;      
                    default:
                        MessageBox.Show(ex.Message,
                        "Warning",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);                       
                        break;
                 }
            
             }
