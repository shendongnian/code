    List<String> temp = new List<string>();
    
    string strControlType;
    foreach (Control ctrl in this.Controls)
    {
        strControlType = Convert.ToString(ctrl.GetType());
        if (strControlType == "System.Windows.Forms.CheckBox")
        {
            temp.Add(ctrl.Text);
        }
    }
