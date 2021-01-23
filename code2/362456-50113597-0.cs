    public partial class GradientPanel : Panel
    {
        private Color _startColor = Color.Transparent;
        private Color _stopColor = Color.Transparent;
        private bool _angleScales = false;
        private int _angle = 0;
    
    
        /// <summary>
        /// litle helper to redraw when property changes, a litle OnNofifyChanged for the 
        /// IDE causing it to update
        /// </summary>
        /// <typeparam name="T">Making sure the values are comparable</typeparam>
        /// <param name="field">the field that is compared</param>
        /// <param name="value">the value that is assigned</param>
        /// <remarks>Updates re-paints the panel when needed</remarks>
        private void Set<T>(ref T field, T value)
        {
            if (field.Equals(value))
                return;
            field = value;
            base.Refresh();
        }
    
        [Category("Appearence"),Description("Specifies the start colour")]
        public Color StartColor  {    get => _startColor;  set => Set(ref _startColor, value); }
    
        [Category("Appearence"), Description("Specifies the stop colour")]
        public Color StopColor { get => _stopColor; set => Set(ref _stopColor, value); }
    
        [Category("Appearence"), Description("The angle, measured in degrees clockwise from the x-axis, of the gradient's orientation line.")]
        public int Angle { get => _angle; set => Set(ref _angle , value);        }
    
        [Category("Appearence"), Description("If Set to true to specify that the angle is affected by the transform associated with this panel")]        
        public bool AngleScales { get => _angleScales; set => Set(ref _angleScales, value); }
    
        protected override void OnPaint(PaintEventArgs e)
        {
    
            LinearGradientBrush br = new LinearGradientBrush(e.ClipRectangle, StartColor, StopColor, Angle, AngleScales);
            e.Graphics.FillRectangle(br, e.ClipRectangle);
            base.OnPaint(e);
        }
    }
