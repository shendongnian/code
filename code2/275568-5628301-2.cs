    public class Form
    {
        Initialise()
        {
            this.Loaded += FormLoaded;
        }
        private void FormLoaded(object sender, EventArgs e)
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
