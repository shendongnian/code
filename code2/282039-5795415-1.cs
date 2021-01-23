    Form2
    {
        bool FormClosing;
    
        // Second form constructor
        Form2()
        {
            FormClosing = false;
            this.MouseDown += new MouseEventHandler(MouseDown);
        }
    
        // Event handler called when mouse is pressed
        void MouseDown(Object sender, MouseEventArgs e)
        {
            // Notify other form we have handled mouse down event
            if (FormClosing)
                e.Handled = true;
        }
        // Handler for when button close is pressed
        CloseButtonClick(Object sender, EventArgs e)
        {
            FormClosing = true;
        }
