<TextBox Text="{Binding Klant, Mode=TwoWay, UpdateSourceTrigger=PropertyChanged}"/>
    public class RFPGegevens
    {
        private string _klant;
        public String Klant
        {
            get { return _klant; }
            set {
                  _klant = value; 
                  //Raise the property changed event here
                }
        }
     }
