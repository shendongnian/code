    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    namespace Comboboxrenklendir
    {
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
 
        private void cmbrenkli_DrawItem(object sender, DrawItemEventArgs e)
        {
           
            Color HighlightColor = Color.Red;
                        
            if (e.Index >=0)
            {
              
                //int sayi = cmbrenkli.Items.Count;
          
                string deger = cmbrenkli.Items[e.Index].ToString();
                if (deger == "30"|| deger == "50")
                {
                    e.Graphics.FillRectangle(new SolidBrush(HighlightColor), e.Bounds);
                }
               
                e.Graphics.DrawString(cmbrenkli.Items[e.Index].ToString(), e.Font, new SolidBrush(cmbrenkli.ForeColor), new Point(e.Bounds.X, e.Bounds.Y));
                e.DrawFocusRectangle();
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            cmbrenkli.Items.Add("10");
            cmbrenkli.Items.Add("20");
            cmbrenkli.Items.Add("30");
            cmbrenkli.Items.Add("40");
            cmbrenkli.Items.Add("50");
        }
    }
    }
 
