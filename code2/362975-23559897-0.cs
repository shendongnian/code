        try
        {
            if (RadioButtonList1.SelectedItem.ToString() == "Sum Of Digit")
            {
                string a = tbInput.Text;
                int sum = 0;
                for (int i = 0; i < a.Length; i++)
                {
                    sum = sum + Convert.ToInt32(a[i].ToString());
                }
                lblResult.Text = sum.ToString();
            }
            else if (RadioButtonList1.SelectedItem.ToString() == "InterChange Number")
            {
                string interchange = tbInput.Text;
                string result = "";
                int condition = Convert.ToInt32(interchange.ToString());
                if (condition <= 99)
                {
                    result = interchange[interchange.Length - 1].ToString() + interchange[0].ToString();
                    lblResult.Text = result.ToString();
                }
                else
                {
                    MyMessageBox("Number Must Be Less Than 99");
                }
            }
            else if (RadioButtonList1.SelectedItem.ToString() == "Sum Of First n last Digit")
            {
                //example
            }
            else
            {
                MyMessageBox("Not Found");
            }
        }
        catch (Exception ex)
        {
            
           MyMessageBox(ex.ToString());
        }
    }
    public void MyMessageBox(string text)
    {
        string script = "alert('"+text+"');";
        ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScripts", script, true);
    }
}
`
