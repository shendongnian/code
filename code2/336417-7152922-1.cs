    int currentTabIndex = 1;
    WebControl postBackCtrl = (WebControl)GetControlThatCausedPostBack(Page);                
    foreach (PlaceHolder plcHolderCtrl in pnlWorkOrderActuals.Controls.OfType<PlaceHolder>())
    {
        foreach (GuardActualHours entryCtrl in plcHolderCtrl.Controls.OfType<GuardActualHours>())
        {
            foreach (Control childCtrl in entryCtrl.Controls.OfType<Panel>())
            {
                if (childCtrl.Visible)
                {
                    foreach (RadDateInput dateInput in childCtrl.Controls.OfType<RadDateInput>())
                    {
                        dateInput.TabIndex = (short)currentTabIndex;
                        if (postBackCtrl != null)
                        {
                            if (dateInput.TabIndex == postBackCtrl.TabIndex + 1)
                                dateInput.Focus();
                        }
                        currentTabIndex++;
                    }
                }                        
            }
        }
    }
