     public void MainForm_AppStateChanged(int val)
        {
    Context.Post((a)=> {
         
            if (val == 1)
            {                
                totDwn.Text = "00:00:00";
                totAct.Text = "00:00:00";                
            }
            else if (val == 0)
            {                
                tt.Reset();
                sw.Reset();
            }
    },null);
        }
                
