    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    
    namespace StackoverflowHelp
    {
      public partial class Form2 : Form
      {
        public Form2()
        {
          InitializeComponent();
    
          DrawCircle(10, 10);
        }
    
        public void DrawCircle(int x, int y)
        {
          Graphics gf = Graphics.FromImage(pictureBox1.Image);
          gf.DrawEllipse(new Pen(Color.Red), new Rectangle(x, y, 20, 20));
          pictureBox1.Refresh();
          pictureBox1.Invalidate();
          pictureBox1.Update();
        }
      }
    }
