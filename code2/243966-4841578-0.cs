    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using System.Collections;
    
    namespace MouseVelocity
    {
        public partial class Form1 : Form
        {
            System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
            Queue timePoints;
    
            public Form1()
            {
                sw.Start();
                timePoints = new Queue(100);
                InitializeComponent();
            }
    
            private void Form1_MouseMove(object sender, MouseEventArgs e)
            {
                addPoint(e);
            }
    
            private void addPoint(MouseEventArgs e)
            {
                timePoints.Enqueue(new TimePoint(new Point(e.X, e.Y), sw.ElapsedMilliseconds));
                if (timePoints.Count == 40) timePoints.Dequeue();
                object[] array = timePoints.ToArray();
                TimePoint tip = (TimePoint)array[array.Length - 1];
                TimePoint end = (TimePoint)array[0];
                long deltaX = tip.point.X - end.point.X;
                long deltaY = tip.point.Y - end.point.Y;
    
                long distance = deltaX * deltaX + deltaY * deltaY;
    
                long deltaT = tip.time - end.time;
                double velocity_modulo = Math.Sqrt(distance) / deltaT;
                double velocity_X = deltaX / (double)deltaT;
                double velocity_Y = deltaY / (double)deltaT;
                label1.Text = string.Format("|V| = {0}; Vx = {1}; Vy = {2}", velocity_modulo, velocity_X, velocity_Y);
            }
    
        }
        public class TimePoint
        {
            public Point point;
            public long time;
    
            public TimePoint(Point pt, long ms)
            {
                point = pt;
                time = ms;
            }
        }
    }
