    class MyControl
        : Control
    {
        public MyControl()
        {
            ...
            MouseWheelHandler.Add(this, MyOnMouseWheel);
        }
        void MyOnMouseWheel(MouseEventArgs e)
        {
            ...
        }
    }
