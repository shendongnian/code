    System.Windows.Controls.Canvas.SetLeft(Gate_list[Gate_list.Count - 1].Rectangle, Pos.X);
----------
    public class Gate_Class
    {
        public Gate_Class(int tag, Rectangle rectangle)
        {
            //...
            Rectangle = rectangle;
        }
        public Rectangle Rectangle { get; }
    }
