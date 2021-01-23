        protected void CustomValidatorDelLN_ServerValidate(object sender, ServerValidateEventArgs args)
        {
            
            args.IsValid = isValid();
        }
        
    	
    protected bool isValid()
    {
    	
    	bool is_valid = txtDeliveryLastName.Text != "";
            txtDeliveryLastName.BackColor = is_valid ? System.Drawing.Color.White : System.Drawing.Color.LightPink;
    	return is_valid;
    }
