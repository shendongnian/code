    class SurroundingClass
    {
        private void SetTextboxes(datatable DT)
        {
            //Clear the previous textboxes
            pnlLayoutExpenses.Controls.clear();
           //loop through table and create new textboxes
            foreach (DataRow row in DT.Rows)
                formAddTextbox(row("dataTableColumnWhichHoldsTextboxText"));
        }
    
    
    
        private void formAddTextbox(string fieldname)
        {
            Integer elementCount = 0;
            TextBox txtYourField = new TextBox();
            txtYourField.Width = 100;
            txtYourField.Height = 20;
            //txtYourField.ReadOnly = true;
            txtYourField.Text = fieldname;
            txtYourField.tag = elementCount; 
    
    
            // Use tableLayoutPanel
            pnlLayoutExpenses.SetCellPosition(txtType, new TableLayoutPanelCellPosition(0, elementCount));
    
            pnlLayoutExpenses.Controls.Add(txtType);
        }
    }
