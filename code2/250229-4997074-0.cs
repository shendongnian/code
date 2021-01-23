    public class Ninja{
        Ninja(){
        }
    
        public void ThrowShirikin(int numberOfShirikins){
            bool errorsExist = false;
            try{
                if(numberOfShirikins == 0){ showUserMessage("Invalid number of shirikins", MessageType.Information); }
            }
            catch(ArgumentException e){
                showUserMessage(e.Message, MessageType.Exception, e);
            }
    
            if(!errorsExist){
                //Throw shirikin
            }
        }
       private showUserMessage(string message, MessageType type, Exception ex = null){
            MessageBox.Show(message);
       }
    }
