    public bool CheckRadioButtons(RadioButton radioButtonA, RadioButton radioButtonB)
    {
        //none of them are selected
        if ((!radioButtonA.Checked) && (!radioButtonB.Checked))
        {
            return false;
        }
        else
        {
            MessageBox.Show("You forgot to select a RadioButton!");
            return true;
        }
    }
