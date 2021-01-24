    bool[] buttons = new bool[10];
    private void button1_Click(object sender, EventArgs e)
    {
         if (buttons[0])
         {
             // Code.....
             buttonToggle(0);
             // Here I change the color based on the estate of the correspondent bool variable
         }
    }
    private void buttonToggle(int btn)
    {
        buttons[btn] = false;
        for(int i = 0; i<10; i++)
        {
            if (i != btn)
            {
                buttons[i] = true;
            }
        }
    }
