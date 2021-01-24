    using System;
    using System.Drawing;
    using System.Windows.Forms;
    namespace WindowsForms
    {
       public class TestBiggerCheckBox : CheckBox
       {
            #region variables
            private int _boxsize = 14;
            private int _boxlocatx = 0;
            private int _boxlocaty = 0;
            private int _textX = 16;
            private int _textY = 1;
            private Color _boxBackColor = Color.Transparent;
            private Color _tickColor = Color.Black;
            private float _tickSize = 11f;
            private Color _boxColor = Color.Black;
            private float _tickLeftPosition = 0f;
            private float _tickTopPosition = 0f;
            #endregion
    
            #region Properties
            public int TextLocationX
            {
                get { return _textX; }
                set { _textX = value; Invalidate(); }
            }
    
            public int TextLocationY
            {
                get { return _textY; }
                set { _textY = value; Invalidate(); }
            }
    
            public int BoxSize
            {
                get { return _boxsize; }
                set { _boxsize = value; Invalidate(); }
            }
    
            public int BoxLocationX
            {
                get { return _boxlocatx; }
                set { _boxlocatx = value; Invalidate(); }
            }
    
            public int BoxLocationY
            {
                get { return _boxlocaty; }
                set { _boxlocaty = value; Invalidate(); }
            }
            public Color BoxBackColor
            {
                get { return _boxBackColor; }
                set { _boxBackColor = value; Invalidate(); }
            }
            public Color TickColor
            {
                get { return _tickColor; }
                set { _tickColor = value; Invalidate(); }
            }
            public float TickSize
            {
                get { return _tickSize; }
                set { _tickSize = value; Invalidate(); }
            }
            public Color BoxColor
            {
                get { return _boxColor; }
                set { _boxColor = value; Invalidate(); }
            }
            public float TickLeftPosition
            {
                get { return _tickLeftPosition; }
                set { _tickLeftPosition = value; Invalidate(); }
            }
            public float TickTopPosition
            {
                get { return _tickTopPosition; }
                set { _tickTopPosition = value; Invalidate(); }
            }
            #endregion
            
            #region Constrctors
            public TestBiggerCheckBox()
            {
                Appearance = Appearance.Button;
                FlatStyle = FlatStyle.Flat;
                TextAlign = ContentAlignment.MiddleRight;
                FlatAppearance.BorderSize = 0;
                AutoSize = false;
            }
            #endregion
    
            #region Methods
            protected override void OnPaint(PaintEventArgs pevent)
            {
                try
                {
                    base.OnPaint(pevent);
                    pevent.Graphics.Clear(BackColor);
    
                    //checkbox text - using draw string method with specified location
                    using (SolidBrush brushText = new SolidBrush(ForeColor))
                    {
                        pevent.Graphics.DrawString(Text, Font, brushText, _textX, _textY);
                    }
    
                    //checkbox box -  using rectangle for checkbox box
                    Rectangle _rectangleBox = new Rectangle(_boxlocatx, _boxlocaty, _boxsize, _boxsize);
    
                    //checkbox box -  checckbox box back color and border color
                    using (SolidBrush brushBackColor = new SolidBrush(_boxBackColor))
                    {
                        pevent.Graphics.FillRectangle(brushBackColor, _rectangleBox);
                    }
                    using (Pen penBoxColor = new Pen(_boxColor))
                    {
                        pevent.Graphics.DrawRectangle(penBoxColor, _rectangleBox);
                    }
    
                    //checkbox box -  check and uncheck
                    if (Checked)
                    {
                        using (SolidBrush brush = new SolidBrush(_tickColor))
                        {
                            using (Font wing = new Font("Wingdings", _tickSize))
                            {
                                pevent.Graphics.DrawString("ü", wing, brush, _tickLeftPosition, _tickTopPosition);
                            }
                        }
                    }
                    pevent.Dispose();
                }
                catch (Exception ex)
                {
                    
                }
            }
            #endregion
        }
    }
