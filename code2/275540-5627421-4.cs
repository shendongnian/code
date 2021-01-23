     public List<String> returnList = new List<String>();
    private List<string> GetTextBoxesAndRadioButtons()
    {
        string txt;
        foreach (Control ctr in Page.Controls)
        {
           CallControls(ctr);
           
        }
        return returnList;
    }
    private void CallControls(System.Web.UI.Control p)
    {
        string returntext = "";
        foreach (Control ctrlMain in p.Controls)
        {
            if (ctrlMain.HasControls())
            {
                /* Recursive Call */
                CallControls(ctrlMain);
            }
    if (ctrlMain is TextBox)
                    {
                        TextBox txt = (TextBox)ctrlMain;
                        //txt = (TextBox)FindControl(ctrlMain.UniqueID);
                        returnList.Add(txt.Text);
                    }
                    else if (ctrlMain is RadioButtonList)
                    {
                        RadioButtonList rad = (RadioButtonList)ctrlMain;
                        //rad = (RadioButtonList)FindControl(ctrlMain.UniqueID);
                        returnList.Add(rad.SelectedValue);
                    }
        }
     
    }
