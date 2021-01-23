    protected void CustomValidatorDelLN_ServerValidate(object sender, ServerValidateEventArgs args)
        {
            args.IsValid = isValid(txtDeliveryLastName);
        }
    
        protected bool isValid(System.Web.UI.WebControls.TextBox MyBox)
        {
            bool is_valid = MyBox.Text != "";
            MyBox.BackColor = is_valid ? System.Drawing.Color.White : System.Drawing.Color.LightPink;
            return is_valid;
        }
