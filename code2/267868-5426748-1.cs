            if (Dirty)
            {
    
    
                if (DialogResult.Yes == MessageBox.Show("There are changes that have not been saved and will be lost. Would you like to save them before leaving this form?", "Unsaved Changes", MessageBoxButtons.YesNo))
                {
                    dsOrders.AcceptChanges();
                }
                else
                {
                    frmOrders.ActiveForm.Hide();
    
                    frmMainMenu.Show();
                }
    
            }
