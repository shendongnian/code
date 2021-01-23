    using Microsoft.Phone.Controls;
    public partial class MyControl
    {
        public MyControl()
        {
            InitializeComponent();
            var gl = GestureService.GetGestureListener(asd);
            gl.Flick += new EventHandler<FlickGestureEventArgs>(GestureListener_Flick);
        }
        private void GestureListener_Flick(object sender, FlickGestureEventArgs e)
        {
            if (e.Direction == Orientation.Horizontal)
            {
                if (e.HorizontalVelocity < 0) // determine direction (Right > 0)
                {
                    //Some Action
                }
                else
                {
                    //Some Action
                }
            }
        }
    }
