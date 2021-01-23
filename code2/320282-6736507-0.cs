            if (this.firstButton == null)
            {            
                Office.CommandBarButton btn = (Office.CommandBarButton)cbar.Controls.Add(1, missing, missing, missing, missing);
                btn.Caption = "button1";
                btn.Tag = "button1";
                this.firstButton = btn;
                firstButton.Click += new Office._CommandBarButtonEvents_ClickEventHandler(ButtonClick);
            }
