       public class KeyboardButton : Button
        {
            public void SimulateButtonDown()
            {
                this.OnMouseDown(new MouseEventArgs(MouseButtons.Left, 0, 1, 1, 0));
            }
    
            public void SimulateButtonUp()
            {
                this.OnMouseUp(new MouseEventArgs(MouseButtons.Left, 0, 1, 1, 0));
            }
        }
