    private void timer1_Tick(object sender, EventArgs e) {
        BAL objBAL = new BAL();
        try {
            objBAL.BL_Function1();
        }
        catch (Exception ex) { //TODO: catch more specific exception (not Exception)
            // If BL_Function1() fails, show message...
            MessageBox.Show(ex.Message); 
        } 
        // ...and go ahead
        try {
            objBAL.BL_Function2();
        }
        catch (Exception ex) {
            MessageBox.Show(ex.Message); 
        } 
        try {
            objBAL.BL_Function3();
        }
        catch (Exception ex) {
            MessageBox.Show(ex.Message); 
        } 
        try {
            objBAL.BL_Function4();
        }
        catch (Exception ex) {
            MessageBox.Show(ex.Message); 
        } 
    }
