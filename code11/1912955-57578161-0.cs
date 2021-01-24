    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    
    namespace Mouse_Test
    {
        public partial class Form1 : Form
        {
            ArrayList listOfPoints;
            bool PencilDown;
    
            public Form1()
            {
                InitializeComponent();
    
                listOfPoints = new ArrayList();
                PencilDown = false;
            }
    
            private void Form1_Load(object sender, EventArgs e)
            {
               
            }
    
            private void Form1_MouseDown(object sender, MouseEventArgs e)
            {
                if(e.Button == MouseButtons.Left || e.Button == MouseButtons.Right)
                {
                    Point p = new Point(e.X, e.Y);
                    listOfPoints.Add(p);
                    PencilDown = true;
                    this.statusStrip1.Items[0].Text = "MouseDown";
                }
            }
    
            private void Form1_MouseMove(object sender, MouseEventArgs e)
            {
                Graphics g = this.CreateGraphics();
                Point points = new Point(e.X, e.Y);
                Pen pencil = new Pen(Color.White);
    
                if (e.Button == MouseButtons.Left)
                {
                    pencil = new Pen(Color.BlueViolet);
                }
    
                if(e.Button == MouseButtons.Right)
                {
                    pencil = new Pen(Color.Red);
                }
    
                if(PencilDown)
                {
                    this.statusStrip1.Items[0].Text = "MouseMove";
                    if(listOfPoints.Count > 1)
                    {
                        g.DrawLine(pencil, (Point)listOfPoints[listOfPoints.Count - 1], points);
                    }
                    listOfPoints.Add(points);
                }
            }
    
            private void Form1_MouseUp(object sender, MouseEventArgs e)
            {
                PencilDown = false;
                this.statusStrip1.Items[0].Text = "MouseUp";
            }
    
            private void Form1_FormClosed(object sender, FormClosedEventArgs e)
            {
                 
            }
        }
    }
