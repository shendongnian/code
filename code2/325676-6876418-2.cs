    protected void buttonChooseAnother_Click(object sender, EventArgs e) 
    {     
        switch(CanonicalNum)     
        {         
            case 0:             
                textBoxNewCanonical1.Visible = true;             
                buttonFind1.Visible = true;
                break;         
            case 1:
                textBoxNewCanonical1.Visible = true;
                buttonFind1.Visible = true;             
                textBoxNewCanonical2.Visible = true;
                buttonFind2.Visible = true;             
                break;         
            default:             
                break;     
        }     
        CanonicalNum = CanonicalNum+1; 
        Session["CanonicalNum"] = CanonicalNum;
    }
