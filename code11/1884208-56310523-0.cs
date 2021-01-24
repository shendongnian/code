    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            this.WireControlsOfType<Button>();
        }      
        private void button1_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.Show();
            f2.WireControlsOfType<Button>();
        }
    }
    public static class FormHelper
    {
        public static void WireControlsOfType<T>(this Form frm)
        {
            foreach(var ctl in frm.RecursiveFindControlsByType<T>())
            {
                ctl.MouseDown += _MouseDown;
                ctl.MouseMove += _MouseMove;
                ctl.MouseUp += _MouseUp;
            }
        }
        // Code by Jon Skeet: https://stackoverflow.com/a/2055946/2330053
        public static IEnumerable<Control> RecursiveFindControlsByType<T>(this Control control)
        {
            foreach (Control c in control.Controls)
            {
                if (c is T)
                {
                    yield return c;
                }
                if (c.Controls.Count > 0)
                {
                    foreach (Control ctl in c.RecursiveFindControlsByType<T>())
                    {
                        yield return ctl;
                    }
                }
            }
        }
        private static bool mouseDown;
        private static Point lastLocation;
        private static void _MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            lastLocation = e.Location;
        }
        private static void _MouseMove(object sender, MouseEventArgs e)
        {
            Control source = (Control)sender;
            if (mouseDown)
            {
                source.Location = new Point((source.Location.X - lastLocation.X) + e.X, (source.Location.Y - lastLocation.Y) + e.Y);
            }
        }
        private static void _MouseUp(object sender, MouseEventArgs e)
        {
             mouseDown = false;
        }
    }
