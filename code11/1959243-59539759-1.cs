    public class Clickable 
    {
        private int _counter = 0;
       
        private void SomeControl_Click(object sender, EventArgs e)
        {
            _counter++;
            if (_counter == 5)
            {
                // DO SOMETHING HERE
                MySpecialMethod();
                // And then reset counter so you can click 5 times again
                _counter = 0;
            }
        }
    }
