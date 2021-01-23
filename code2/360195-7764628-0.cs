            protected override void OnFormClosing(FormClosingEventArgs e)
            {
                try
                {
                    ConfirmClose = true;
                    base.OnFormClosing(e);
                    if (e.CloseReason == CloseReason.WindowsShutDown)
                   {
                        //Do some action
                   }
                }
              }
                catch (Exception ex)
                {
                    
                }
            }
