    public class FancyTextBox : TextBox{
    
        private bool _isDefaultText;
        public FancyTextBox(){
             this.Focus += HandleTextBoxFocus;
             this.FocusLost += HandelTextBoxFocusLost;
             UpdateDefaultSettings(true);         
        }
    
        public void HandleTextBoxFocus(object sender, ..){
             UpdateDefaultSettings(false);
        }
        
        public void HandelTextBoxFocusLost(object sender, ...){
            if(string.IsNullOrEmpty(Text){
               //Retain Default Setting.
               UpdateDefaultSettings(true);  
            }
        }
        
        private void UpdateDefaultSettings(bool isDefault){
            _isDefaultText = isDefault;
            if(_isDefaultText){
               Text = "Please enter";
               ForeGround = Color.Grey;  
            }
            else{
               Text = "";
               ForeGround = Color.Black;
            }
        }    
    }
