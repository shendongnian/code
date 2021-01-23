    // the validation should be done in this form when the user 
    // presses OK. But that's up to you to figure out
    public class PlaceAndTemperatureForm : Form
    {
        public PlaceAndTemperature GetPlaceAndTemperature()
        {
            return new PlaceAndTemperature(txtName.Text, int.Parse(txtTemperature .Text));
        }
    }
