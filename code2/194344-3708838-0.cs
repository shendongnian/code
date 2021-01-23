              frmReaserchData childForm = null;
              foreach (Form f in this.MdiChildren)
              {
                  if (f is frmReaserchData)
                  {
                      // found it 
                      childForm = (frmReaserchData)f;
                      break;
                  }
                  else
                  {                                                   
                        f.WindowState = FormWindowState.Minimized; 
                        f.Show();                          
                  }
              }
              if (childForm != null)
              {                    
                  childForm.Focus();
              }
              else
              {
                  childForm = new frmReaserchData();
                  childForm.MdiParent = this;
                  childForm.Show();                     
              }
