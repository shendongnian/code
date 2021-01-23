    public bool CheckValidity()
    {
            bool is_valid = txtDeliveryLastName.Text != "";
            txtDeliveryLastName.BackColor = is_valid ? System.Drawing.Color.White : System.Drawing.Color.LightPink;
            return is_valid;
    }
