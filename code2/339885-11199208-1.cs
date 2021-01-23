    class CustomEventArgs : EventArgs {
        public string Param1 {get; set;}
        public int Param2 {get; set;}
        public bool Param3 {get; set;}
        ...
    }
    
    class FormA:Form {
        ...
        private void OnCallBack(object sender, CustomEventArgs args){
            // put your process here
            ...     
        }        
    }
    class FormB:Form {
        ...
        btnOK_Click(){
            EventHandler<CustomEventArgs> handler = this.CallBack;
            if (handler != null)
            {
                // set parameter 
                CustomEventArgs eventArgs = new CustomEventArgs();
                eventArgs.Param1 = "param1";
                eventArgs.Param2 = 1000;
                eventArgs.Param3 = true;
                // call handler and pass value
                handler(this, eventArgs);
            }            
        }                
        Event EventHandler<CustomEventArgs> CallBack;
    }
