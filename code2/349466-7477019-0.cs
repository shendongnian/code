    foreach (Control masterControl in Page.Controls)
    {
        if (masterControl is MasterPage)
        {
            foreach (Control formControl in masterControl.Controls)
            {
                if (formControl is System.Web.UI.HtmlControls.HtmlForm)
                {
                    foreach (Control contentControl in formControl.Controls)
                    {
                        if (contentControl is ContentPlaceHolder)
                        {
                            foreach (Control childControl in contentControl.Controls)
                            {
                                if(childControl is CheckBoxList)
                                {
                                    ((CheckBoxList)childControl).SelectedIndex = 1;
                                }
                            }
                        }
                    }
                }
            }
        }
    }
