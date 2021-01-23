    using System;
    using System.Drawing;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;
    using System.Diagnostics;
    using System.Threading;
    namespace ConsoleApplication11
    {
       class Program
        {
           [DllImport("user32.dll")]
           static extern bool SetCursorPos(int X, int Y);   
           public static void LinearSmoothMove(Point newPosition, TimeSpan duration)
           {
               Point start = Cursor.Position;
               int sleep = 200;
               //PointF iterPoint = start;
               // Find the vector between start and newPosition   
               double deltaX = newPosition.X - start.X;
               double deltaY = newPosition.Y - start.Y;
               // start a timer    
               Stopwatch stopwatch = new Stopwatch();
               stopwatch.Start();
               double timeFraction = 0.0;
               do
               {
                   timeFraction = (double)stopwatch.Elapsed.Ticks / duration.Ticks;
                   if (timeFraction > 1.0)
                    timeFraction = 1.0;
                   PointF curPoint = new PointF((float)(start.X + timeFraction * deltaX), (float)(start.Y + timeFraction * deltaY));
                   SetCursorPos(Point.Round(curPoint).X, Point.Round(curPoint).Y);
                   Thread.Sleep(sleep);
               } while (timeFraction < 1.0);
           }
           static void Main(string[] args)
           {
               TimeSpan delayt = new TimeSpan(1);
               LinearSmoothMove(new Point(20, 40), delayt);
               Console.Read();
            }       
        }
    }
