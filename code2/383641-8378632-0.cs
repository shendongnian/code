    protected void btnRegister_Click(object sender, EventArgs e) {
        switch (cmbEvents.SelectedText) {
            case "OnLoad":
                MyControl.OnLoad += (s, e) => SomeSelectedControl.Text = SomeInputControl.Text;
                break;
            //... other cases
        }
    }
