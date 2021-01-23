    public Form_Class{
        // Methods that will do the updating
        public void MethodToBeCalledByClass(string messageToSend)
        {
           if (InvokeRequired) { 
               Invoke(new OutputDelegate(UpdateText),messageToSend); 
           }
        }
    
        public delegate void OutputDelegate(string messageToSend);
        public void UpdateText(string messageToSend)
        {
           label1.Text = messageToSend;
        }
    }
