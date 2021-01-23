    protected void btnAdd_Click(object sender, EventArgs e) {
        int feet = 0;
        int inches = 0;
        
        if (!int.TryParse(txtFoot.Text, out feet)) 
            throw new FormatException(string.Format("{0} is not a valid value", txtFoot.Text));
       if (!int.TryParse(txtInches.Text, out inches))
           throw new FormatException(string.Format("{0} is not a valid value", txtInches.Text));
       double meters = ((double)(string.Format("{0}.{1}", feet, inches)) * .39;
       lblResult.Text = string.Format("{0}", meters);
       lblFootAndInches.Text = string.Format("{0}'{1}\"", feet, inches);
    }
