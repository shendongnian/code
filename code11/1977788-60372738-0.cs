    private void GetMaxBranchCode()
    {    
        int BranchCode = Int32.Parse(txtBranchCode.Text); //Textbox value is null
                    SSWHContext context = new SSWHContext();
                    var Code = context.Branches.Where(a => a.Id == BranchCode)
                       .OrderByDescending(a => a.BranchCode).FirstOrDefault();
                    if (Code == null)
                    {
                        txtBranchCode.Text = "1";
                        return;
                    }
                    txtBranchCode.Text = (Code.BranchCode + 1).ToString();
                }
    }
