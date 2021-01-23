    using System.Windows.Shapes;
    using System.Windows.Controls;
    using System.Windows;
    namespace SilverlightApplication1
    {
        public struct Point
        {
            public static readonly Point Empty;
            public Point(int x, int y) { _x = x; _y = y; }
            int _x;
    
            public int X
            {
                get { return _x; }
                set { _x = value; }
            }
            int _y;
    
            public int Y
            {
                get { return _y; }
                set { _y = value; }
            }
        }
        public class RealRect
        {
            Rectangle mRect = new Rectangle();
    
            #region Class Local Variables
    
            private SilverlightApplication1.Point mStart;
    
            public SilverlightApplication1.Point MStart
            {
                get { return mStart; }
                set { mStart = value; }
            }
            private SilverlightApplication1.Point mEnd;
            private SilverlightApplication1.Point mRealStart;
            private SilverlightApplication1.Point mRealEnd;
            private System.Windows.Size mRealSize;
            private bool isStatus = false;
    
            public bool IsStatus
            {
                get { return isStatus; }
                set { isStatus = value; }
            }
            private SilverlightApplication1.Point mTempPoint;
    
            #endregion
    
    
            public RealRect(int x, int y, bool start)
            {
                mTempPoint = new SilverlightApplication1.Point(x, y);
                IsStatus = false;
                mEnd = Point.Empty;
                mRealEnd = Point.Empty;
            }
            public void ClearStartTemp()
            {
                IsStatus = false;
                mTempPoint = Point.Empty;
            }
            public void StartRect()
            {
                IsStatus = true;
                mStart = mTempPoint;
                mRealStart = mTempPoint;
                
            }
    
    
            /// <summary>
            /// Ending X Value of rectangle
            /// </summary>
            public int EndX
            {
                set { mEnd.X = value; }
            }
    
            /// <summary>
            /// Ending Y Value of rectangle
            /// </summary>
            public int EndY
            {
                set { mEnd.Y = value; }
            }
    
            /// <summary>
            /// Get the corrected rectangle
            /// </summary>
            public Rectangle Rect
            {
                get
                {
                    MakeReal();
    
                    return mRect;
    
                }
            }
    
            public void MakeReal()
            {
                //Started top left, ended bottom right
                if (mEnd.X > mStart.X && mEnd.Y > mStart.Y)
                {
                    mRealStart = mStart;
                    mRealEnd = mEnd;
                    mRealSize = new Size(mRealEnd.X - mRealStart.X, mRealEnd.Y - mRealStart.Y);
                   // return;
                }
    
                //Started bottom right, ended top left
                else if (mEnd.X < mStart.X && mEnd.Y < mStart.Y)
                {
                    mRealEnd = mStart;
                    mRealStart = mEnd;
                    mRealSize = new Size(mRealEnd.X - mRealStart.X, mRealEnd.Y - mRealStart.Y);
                   // return;
                }
    
                //Started top right left, ended bottom left
                else if (mEnd.X < mStart.X && mEnd.Y > mStart.Y)
                {
                    mRealStart.X = mEnd.X;
                    mRealStart.Y = mStart.Y;
                    mRealEnd.X = mStart.X;
                    mRealEnd.Y = mEnd.Y;
                    mRealSize = new Size(mRealEnd.X - mRealStart.X, mRealEnd.Y - mRealStart.Y);
                   // return;
                }
    
                //Started bottom left, ended top right
                else if (mEnd.X > mStart.X && mEnd.Y < mStart.Y)
                {
                    mRealStart.X = mStart.X;
                    mRealStart.Y = mEnd.Y;
                    mRealEnd.X = mEnd.X;
                    mRealEnd.Y = mStart.Y;
                    mRealSize = new Size(mRealEnd.X - mRealStart.X, mRealEnd.Y - mRealStart.Y);
                   // return;
                }
                Canvas.SetLeft(mRect, mRealStart.X);
                Canvas.SetTop(mRect, mRealStart.Y);
                mRect.Width = mRealSize.Width;
                mRect.Height = mRealSize.Height;
            }
        }
    
    
    }
