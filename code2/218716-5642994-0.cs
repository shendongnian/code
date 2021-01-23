    foreach (Control ctlMaster in Page.Controls)
        {
            if (ctlMaster is MasterPage)
            {
                foreach (Control ctlForm in ctlMaster.Controls)
                {
                    if (ctlForm is HtmlForm)
                    {
                        foreach (Control ctlContent in ctlForm.Controls)
                        {
                            if (ctlContent is ContentPlaceHolder)
                            {
                                foreach (Control ctlChild in ctlContent.Controls)
                                {
                                    //Do something!
                                }
                            }
                        }
                    }
                }
            }
        }
              
