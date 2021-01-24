private void Fnum_TextChanged(object sender, EventArgs e)
{
    if (!string.IsNullOrEmpty(fnum.Text)) 
    { 
        if (double.TryParse(fnum.Text, out firstnumber) == false){
            // notify user in message box or throw error
        }
    }
}
After this runs, if there is no error that means `fnum.Text` parsed and is now stored in your `firstnumber` variable.
