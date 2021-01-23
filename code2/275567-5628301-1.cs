    public class Form
    {
        Initialise()
        {
            // pick a button
            pickedButton.Flash();
        }
        private void Button_Click(object sender, EventArgs e)
        {
            if (sender == pickedButton)
            {
                pickedButton = pickButton();
            }
            else
            {
                message = "Sorry wrong button, try again";
            }
            pickedButton.Flash();
        }
    }
    public class Button
    {
        public void Flash()
        {
            // loop N times turning button on/off
        }
    }
