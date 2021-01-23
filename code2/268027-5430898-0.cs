        void dgv_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
              
            if (e.Control is TextBox)
            {
                DataGridView dgv = sender as DataGridView;
                DataGridViewColumn dgvCol= dgv.CurrentCell.OwningColumn;
                TextBox tb = (TextBox)e.Control;
                foreach (cFieldLayoutType fieldLayout in FieldLayouts)
                {
                    string context = dgvCol.Name.Substring(dgvCol.Name.LastIndexOf(".") + 1);
                    if (context == fieldLayout.columnName)
                    {
                        //See URL to check why it is done this way: http://msdn.microsoft.com/en-us/library/system.windows.forms.datagridview.editingcontrolshowing.aspx
                        KeyPressEventHandler kpehAmount = new KeyPressEventHandler(oTextBoxAmount_KeyPress);                        
                        KeyPressEventHandler kpehDecimal = new KeyPressEventHandler(oTextBoxDecimal_KeyPress);
                        KeyPressEventHandler kpehDate = new KeyPressEventHandler(oTextBoxDate_KeyPress);
                        EventHandler textChangedHandlerAmount = new EventHandler(oTextBoxAmount_TextChanged);
                        tb.Leave += new EventHandler(textBox_DeregisterCellEventsOnLeave);                        
                        switch (fieldLayout.Type)
                        {
                            case cFieldType.amount:
                                {
                                    tb.KeyPress += kpehAmount;
                                    
                                    tb.TextChanged += textChangedHandlerAmount;
                                    break;
                                }
                            case cFieldType.numeric:
                                {
                                    tb.KeyPress += kpehDecimal;
                                    break;
                                }
                            case cFieldType.date:
                                {
                                    tb.KeyPress += kpehDate;
                                    break;
                                }
                            case cFieldType.text:
                                {
                                    break;
                                }
                        }
                    }
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void textBox_DeregisterCellEventsOnLeave(object sender, EventArgs e)
        {
            TextBox tb = (TextBox)sender;
            KeyPressEventHandler kpehAmount = new KeyPressEventHandler(oTextBoxAmount_KeyPress);
            KeyPressEventHandler kpehDecimal = new KeyPressEventHandler(oTextBoxDecimal_KeyPress);
            KeyPressEventHandler kpehDate = new KeyPressEventHandler(oTextBoxDate_KeyPress);
            EventHandler textChangedHandlerAmount = new EventHandler(oTextBoxAmount_TextChanged);
            EventHandler textBoxDeregisterOnLeave = new EventHandler(textBox_DeregisterCellEventsOnLeave);
            tb.KeyPress -= kpehAmount;
            tb.KeyPress -= kpehDate;
            tb.KeyPress -= kpehDecimal;
            tb.TextChanged -= textChangedHandlerAmount;
            tb.Leave -= textBoxDeregisterOnLeave;       
        }   
