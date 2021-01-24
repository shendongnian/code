    public void DoJob()
        {
         FormWorkFlow frm = (FormWorkFlow)Application.OpenForms["FormWorkFlow"];
          if (frm.InvokeRequired)
             {
                frm.BeginInvoke(new Action(() =>
                {
                    //This is public function in form that sets the listview control text
                    frm.SetListViewEventItems("This call is from the class", "it works"); 
                }));
             }
          else
             {
             }
        }
