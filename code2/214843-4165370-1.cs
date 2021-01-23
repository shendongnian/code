    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Windows.Forms;
    using System.Drawing.Drawing2D;
    namespace Grafi
    {
        public partial class Form1 : Form
        {
            bool isDrawing;
            // our collection of strokes for drawing
            List<List<Point>> _strokes = new List<List<Point>>();
            // the current stroke being drawn
            List<Point> _currStroke;
            // our pen
            Pen _pen = new Pen(Color.Red, 2); 
            public Form1()
            {
                InitializeComponent();
            }
            private void chartTemperature_MouseDown(object sender, MouseEventArgs e)
            {
                isDrawing = true;
                // mouse is down, starting new stroke
                _currStroke = new List<Point>();
                // add the initial point to the new stroke
                _currStroke.Add(e.Location);
                // add the new stroke collection to our strokes collection
                _strokes.Add(_currStroke);
            }
            private void chartTemperature_MouseMove(object sender, MouseEventArgs e)
            {
                if (isDrawing)
                {
                    // record stroke point if we're in drawing mode
                    _currStroke.Add(e.Location);
                    Refresh(); // refresh the drawing to see the latest section
                }
            }
            private void chartTemperature_MouseUp(object sender, MouseEventArgs e)
            {
                isDrawing = false;
            }
            private void chartTemperature_Paint(object sender, PaintEventArgs e)
            {
                // now handle and redraw our strokes on the paint event
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                foreach (List<Point> stroke in _strokes.Where(x => x.Count > 1))
                    e.Graphics.DrawLines(_pen, stroke.ToArray());
            }
        }
    }
