    class FormA:Form {
        ...
        btnAdd_Click(){
             FormB formB = new FormB();
             formB.CallBack += this.OnCallBack;
        }
        
        private void OnCallBack(object sender, EventArgs args){
            // put your process here
        }
    }
    class FormB:Form {
        ...
        btnOK_Click(){
            EventHandler<EventArgs> handler = this.CallBack;
            // if not null, call handler
            if (handler != null)
            {
                // you can make custom EventArgs, pass parameter with it
                handler(this, new EventArgs());
            }            
        }
        Event EventHandler<EventArgs> CallBack;                
    }
