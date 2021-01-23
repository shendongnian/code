    // pseudo code
    textbox1.Validating += ValidateTx1();
    textbox2.Validating += ValidateTx2();
    btnOk.Click += OkBtnClicked();
    private void OkBtnClicked(...)
    {
        if(ValidateAll())
        {
           this.Close();
        }
    }
    private bool ValidateTx1(...)
    {
       DoTx1Validation();
    }
    private bool ValidateTx2(...)
    {
       DoTx2Validation();
    }
    private bool ValidateAll()
    {
       bool is_valid = DoTx1Validation();
       return (is_valid && DoTx2Validation());
    }
