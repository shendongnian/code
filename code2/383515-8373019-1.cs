       public class FancyTextBox : TextBox{
    private bool _isDefaultText;
    public FancyTextBox(){
         UpdateDefaultSettings(true);         
    }
    protected override void OnGotFocus(EventArgs e)
    {
        base.OnGotFocus(e);
        UpdateDefaultSettings(false);
    }
    protected override void OnLostFocus(EventArgs e)
    {
        base.OnLostFocus(e);
        if (String.IsNullOrEmpty(Text))
        {
            //Retain Default Setting.
            UpdateDefaultSettings(true);
        }
    }
    private void UpdateDefaultSettings(bool isDefault){
        _isDefaultText = isDefault;
        if(_isDefaultText){
           Text = "Please enter";
           this.ForeColor= Color.Gray;  
        }
        else{
           Text = "";
           ForeColor = Color.Black;
        }
    }    
}
