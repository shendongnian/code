       private void GetCurrentItem(int location)
       {
             if (this.listViewModels.InvokeRequired)
             {
                 Invoke( new Action ()=>{
                    //do what ever you want to do here
                    // this.listViewModels.Items[location].Text;
                 })); 
             }
             else
             {
              this.listViewModels.Items[location].Text;
             }
       }
