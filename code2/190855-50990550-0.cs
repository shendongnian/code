    protected override void CreateChildControls()
    {
                base.CreateChildControls();
                loadCheckbox();
    }
    
    public void loadCheckbox()
            {
                    int checkCount = 10;
                    CheckBox[] chk = new CheckBox[checkCount];
                   
                    for(int i == 0; i<=10; i++)
                   
                    {
    
                        chk[i] = new CheckBox();
    
                        chk[i].ID = rCmt.cmtkey;
    
                        chk[i].Text = rCmt.rootcommitteename;
      
                        Panel1.Controls.Add(chk[i]);
               
                      
                    }
    
    
                }
