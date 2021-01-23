    public void SaveCurrentTab(string currentTabIndex)
            {
                switch (Convert.ToInt32(currentTabIndex))
                {
                    case (int)MainInfoPnl.ClientID:
                        PartialSave1();
                        break;
                    case (int)ContactInfoPnl.ClientID:
                        PartialSave2();
                        break;
                    case (int)BankInfoPnl.ClientID:
                        PartialSave3();
                        break;
                    case (int)ServicesPnl.ClientID:
                        PartialSave4();
                        break;
                    case (int)AttachmentsPnl.ClientID:
                        PartialSave5();
                        break;
                }
    
            }
