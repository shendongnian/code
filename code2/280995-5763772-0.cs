    void SettingControls()
    {
        for (int i = 0; i < listBox1.Items.Count; i++)
        {
            string[] ListText;
            ListText = listBox1.Items[i].ToString().Split('.');
            if (ListText[0] == ";Control")
            {
                if (ListText[1] == "Form")
                {
                    ...
                    i+=6;
                }
                else
                {
                    ...
                    i+=7;
                }
            }
        }
    }
