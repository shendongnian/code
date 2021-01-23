    private void taxChanged(object sender, EventArgs e)
            {
                 updateTax();
            }
    
    
    private void updateTax()
            {
                // the rest of your logic, checking state, etc. 
                // 
                this.Tax.Text = aValueCalculatedInYourLogicAbove;
                updateTotal()
            }
    private void updateTotal()
            {
                // sum up whatever fields need to be summed 
                // 
                this.Tax.Text = aTotalValueCalculatedAbove;
            }
