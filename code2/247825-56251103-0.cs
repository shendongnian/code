    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    namespace MoveButton
    {
    public partial class Form1 : Form
    {
        bool clicked = false;
        Point iOld = new Point();
        Point iClick = new Point();
        public Form1()
        {
            InitializeComponent();
        }
        private Point ConvertFromChildToForm(int x, int y, Control control)
        {
            Point p = new Point(x, y);
            control.Location = p;
            return p;
        }
        private void button1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                Point p = ConvertFromChildToForm(e.X, e.Y, button1);
                iOld.X = p.X;
                iOld.Y = p.Y;
                iClick.X = e.X;
                iClick.Y = e.Y;
                clicked = true;
            }
        }
        private void button1_MouseMove(object sender, MouseEventArgs e)
        {
            if (clicked)
            {
                Point p = new Point();//in form coordinates
                p.X = e.X + button1.Left;
                p.Y = e.Y + button1.Top;
                button1.Left = p.X - iClick.X;
                button1.Top = p.Y - iClick.Y;
            }
        }
        private void button1_MouseUp(object sender, MouseEventArgs e)
        {
            clicked = false;
        }
       }
    }
    
