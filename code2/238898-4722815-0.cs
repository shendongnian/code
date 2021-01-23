using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Reflection;
namespace xxxxx.xxxxx.xxxxx.Controls
{
    /// <summary>
    /// Custom Drawn menu item for INVU link
    /// </summary>
    public partial class INVULinkMenuItem : System.Windows.Forms.MenuItem
    {
        //- MEMBER VARIABLES --------------------------------------------------------------------------------------------------------
        private const int defaultGraphicDimension = 20;
        private Font _font = new Font( "Tahoma", 8f );
        private Icon _icon;
        private int _graphicWidth = defaultGraphicDimension;
        private int _graphicHeight = defaultGraphicDimension;
        private bool _drawGraphic = false;
        private Color m_c1 = Color.FromArgb( 255, 212, 139 );
        private Color m_c2 = Color.FromArgb( 255, 177, 90 );
        private Color m_BackColour1 = Color.FromArgb( 247, 248, 249 );
        private Color m_BackColour2 = Color.FromArgb( 199, 198, 214 );
        private Color m_BorderColour = Color.FromArgb( 124, 124, 148 );
        private LinearGradientMode m_LinearGradientMode = LinearGradientMode.Vertical;
        //- PROPERTIES --------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Border Colour
        /// </summary>
        public Color BorderColour
        {
            get
            {
                return m_BorderColour;
            }
            set
            {
                m_BorderColour = value;
            }
        }
        /// <summary>
        /// Back Colour A
        /// </summary>
        public Color BackColourA
        {
            get
            {
                return m_BackColour1;
            }
            set
            {
                m_BackColour1 = value;
            }
        }
        /// <summary>
        /// Back Colour B
        /// </summary>
        public Color BackColourB
        {
            get
            {
                return m_BackColour2;
            }
            set
            {
                m_BackColour2 = value;
            }
        }
        /// <summary>
        /// Colour A
        /// </summary>
        public Color ColourA
        {
            get
            {
                return m_c1;
            }
            set
            {
                m_c1 = value;
            }
        }
        /// <summary>
        /// Colour B
        /// </summary>
        public Color ColourB
        {
            get
            {
                return m_c2;
            }
            set
            {
                m_c2 = value;
            }
        }
        /// <summary>
        /// Direction of the selected item gradient
        /// </summary>
        public LinearGradientMode LinearGradientMode
        {
            get
            {
                return m_LinearGradientMode;
            }
            set
            {
                m_LinearGradientMode = value;
            }
        }
        /// <summary>
        /// The actual text without the accelerator in it.
        /// </summary>
        public string RealText
        {
            get { return GetRealText(); }
        }
        /// <summary>
        /// Whether the icon and icon area should be drawn.
        /// </summary>
        public bool DrawGraphic
        {
            get { return _drawGraphic; }
            set { _drawGraphic = value; }
        }
        /// <summary>
        /// The icon to use with this menu item.
        /// </summary>
        public Icon Icon
        {
            get { return _icon; }
            set
            {
                if ( _icon != null )
                    _icon.Dispose();
                _icon = value;
                if ( _icon != null )
                {
                    _graphicWidth = ( _icon.Width > _graphicWidth ? _icon.Width : _graphicWidth );
                    _graphicHeight = ( _icon.Height > _graphicHeight ? _icon.Height : _graphicHeight );
                }
                else
                {
                    _graphicWidth = defaultGraphicDimension;
                    _graphicHeight = defaultGraphicDimension;
                }
            }
        }
        /// <summary>
        /// The height of the graphic area for the icon.
        /// </summary>
        public int GraphicHeight
        {
            get { return _graphicHeight; }
            set { _graphicHeight = value; }
        }
        /// <summary>
        /// The width of the graphic area for the icon.
        /// </summary>
        public int GraphicWidth
        {
            get { return _graphicWidth; }
            set { _graphicWidth = value; }
        }
        /// <summary>
        /// The font to use for the menu.
        /// </summary>
        public Font Font
        {
            get { return _font; }
            set
            {
                if ( _font != null )
                    _font.Dispose();
                _font = value;
            }
        }
        //- CONSTRUCTOR -------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Default constructor
        /// </summary>
        public INVULinkMenuItem()
            : base()
        {
            base.OwnerDraw = true;
        }
        /// <summary>
        /// Constructor specifying the menu text.
        /// </summary>
        /// <param name="text">The menu text.</param>
        public INVULinkMenuItem( string text )
            : base( text )
        {
            base.OwnerDraw = true;
        }
        /// <summary>
        /// Constructor specifying the menu text and te click event handler.
        /// </summary>
        /// <param name="text">The menu text.</param>
        /// <param name="onClick">The click event handler.</param>
        public INVULinkMenuItem( string text, EventHandler onClick )
            : base( text, onClick )
        {
            base.OwnerDraw = true;
        }
        /// <summary>
        /// Constructor specifying the text and child menu items.
        /// </summary>
        /// <param name="text">The menu text.</param>
        /// <param name="items">The child menu items.</param>
        public INVULinkMenuItem( string text, MenuItem[] items )
            : base( text, items )
        {
            base.OwnerDraw = true;
        }
        //- EVENTS -------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Draw the menu.
        /// </summary>
        /// <param name="e">The event args specifying where to draw.</param>
        protected virtual void DrawItems( DrawItemEventArgs e )
        {
            try
            {
                Rectangle rcBk = e.Bounds;
                Brush br = null;
                Pen nPen = null;
                if ( _drawGraphic )
                {
                    rcBk.X += _graphicWidth;
                }
                if ( ( e.State & DrawItemState.Selected ) != 0 && this.Enabled )
                {
                    br = new LinearGradientBrush( rcBk, m_c1, m_c2, m_LinearGradientMode );
                }
                else
                {
                    br = new LinearGradientBrush( rcBk, m_BackColour1, m_BackColour2, m_LinearGradientMode );
                }
                using ( br )
                {
                    e.Graphics.FillRectangle( br, rcBk );
                    nPen = new Pen( m_BackColour2 );
                    e.Graphics.DrawRectangle( nPen, new Rectangle( rcBk.X, rcBk.Y, rcBk.Width - 1, rcBk.Height ) );
                    _font = new Font( _font, FontStyle.Regular );
                }
                if ( ( e.State & DrawItemState.Selected ) != 0 && this.Enabled )
                {
                    nPen = new Pen( Color.FromArgb( 124, 124, 148 ) );
                    e.Graphics.DrawRectangle( nPen, new Rectangle( rcBk.X, rcBk.Y, rcBk.Width - 1, rcBk.Height - 1 ) );
                    _font = new Font( _font, FontStyle.Regular );
                }
                if ( _drawGraphic )
                {
                    rcBk.X -= _graphicWidth;
                    rcBk.Width = _graphicWidth + 4;
                    using ( br = new SolidBrush( System.Drawing.SystemColors.ControlLight ) )
                    {
                        e.Graphics.FillRectangle( br, rcBk );
                    }
                }
                using ( StringFormat sf = new StringFormat() )
                {
                    sf.SetTabStops( 60, new float[] { 0 } );
                    int left = 4;
                    if ( _drawGraphic )
                    {
                        left = e.Bounds.Left + _graphicWidth + 4;
                    }
                    if ( String.Compare( "-", this.Text ) == 0 )
                    {
                        using ( Pen lineBasePen = new Pen( System.Drawing.SystemColors.ControlDark, 1 ) )
                        {
                            using ( Pen lineHighlightPen = new Pen( System.Drawing.SystemColors.ControlLightLight, 1 ) )
                            {
                                int lineY = ( ( e.Bounds.Bottom - e.Bounds.Top ) / 2 ) + e.Bounds.Top;
                                e.Graphics.DrawLine( lineBasePen, left, lineY, e.Bounds.Right, lineY );
                                e.Graphics.DrawLine( lineHighlightPen, left, lineY + 1, e.Bounds.Right, lineY + 1 );
                            }
                        }
                    }
                    else
                    {
                        if ( this.Enabled )
                        {
                            br = new SolidBrush( Color.Black );
                        }
                        else
                        {
                            br = new SolidBrush( System.Drawing.SystemColors.GrayText );
                        }
                        using ( br )
                        {
                            e.Graphics.DrawString( GetRealText(), _font, br, left, e.Bounds.Top + 2, sf );
                        }
                    }
                }
                if ( _icon != null && _drawGraphic )
                {
                    if ( !this.Checked )
                    {
                        e.Graphics.DrawIcon( _icon, e.Bounds.Left, e.Bounds.Top );
                    }
                    else
                    {
                        e.Graphics.DrawIcon( _icon, e.Bounds.Left + 2, e.Bounds.Top + 2 );
                        if ( !this.Enabled )
                        {
                            nPen = new Pen( SystemColors.GrayText );
                        }
                        else
                        {
                            nPen = new Pen( SystemColors.ControlDarkDark );
                        }
                        using ( nPen )
                        {
                            e.Graphics.DrawRectangle( nPen, 1, e.Bounds.Top, _graphicWidth, _graphicHeight );
                        }
                    }
                }
                else
                {
                    if ( this.Checked )
                    {
                        if ( !this.Enabled )
                        {
                            nPen = new Pen( SystemColors.GrayText );
                        }
                        else
                        {
                            nPen = new Pen( SystemColors.ControlDarkDark );
                        }
                        using ( nPen )
                        {
                            e.Graphics.DrawRectangle( nPen, 1, e.Bounds.Top, 20, 20 );
                        }
                        Point[] Pnts = new Point[ 3 ];
                        Pnts[ 0 ] = new Point( 15, e.Bounds.Top + 6 );
                        Pnts[ 1 ] = new Point( 8, e.Bounds.Top + 13 );
                        Pnts[ 2 ] = new Point( 5, e.Bounds.Top + 10 );
                        if ( this.Enabled )
                        {
                            nPen = new Pen( Color.Black );
                        }
                        else
                        {
                            nPen = new Pen( Color.Gray );
                        }
                        using ( nPen )
                        {
                            e.Graphics.DrawLines( nPen, Pnts );
                        }
                    }
                }
            }
            catch ( Exception ex )
            {
                Classes.ErrorHandler.HandleError( ex, MethodBase.GetCurrentMethod().Name, MethodBase.GetCurrentMethod().DeclaringType.FullName );
            }
        }
        /// <summary>
        /// Measure the size of the menu item. Return the value in the event args.
        /// </summary>
        /// <param name="e">The event args for measuring this item.</param>
        protected virtual void MeasureItems( MeasureItemEventArgs e )
        {
            try
            {
                using ( StringFormat sf = new StringFormat() )
                {
                    sf.SetTabStops( 60, new float[] { 0 } );
                    if ( String.Compare( "-", this.Text ) == 0 )
                    {
                        e.ItemHeight = 3;
                    }
                    else
                    {
                        int textHeight = ( int ) ( e.Graphics.MeasureString( GetRealText(), _font, 10000, sf ).Height );
                        e.ItemHeight = ( textHeight > _graphicHeight ? textHeight : _graphicHeight );
                    }
                    e.ItemWidth = ( int ) ( e.Graphics.MeasureString( GetRealText(), _font, 10000, sf ).Width )
                     + _graphicWidth + 10;
                }
            }
            catch ( Exception ex )
            {
                Classes.ErrorHandler.HandleError( ex, MethodBase.GetCurrentMethod().Name, MethodBase.GetCurrentMethod().DeclaringType.FullName );
            }
        }
        /// <summary>
        /// Triggered by the system to get the menu item measurements.
        /// </summary>
        /// <param name="e">The event args for measuring this item.</param>
        protected override void OnMeasureItem( MeasureItemEventArgs e )
        {
            try
            {
                base.OnMeasureItem( e );
                MeasureItems( e );
            }
            catch ( Exception ex )
            {
                Classes.ErrorHandler.HandleError( ex, MethodBase.GetCurrentMethod().Name, MethodBase.GetCurrentMethod().DeclaringType.FullName );
            }
        }
        /// <summary>
        /// Triggered by the system to get the menu item drawn.
        /// </summary>
        /// <param name="e">The event args specifying where to draw.</param>
        protected override void OnDrawItem( DrawItemEventArgs e )
        {
            try
            {
                e.Graphics.CompositingQuality = CompositingQuality.HighQuality;
                base.OnDrawItem( e );
                DrawItems( e );
            }
            catch ( Exception ex )
            {
                Classes.ErrorHandler.HandleError( ex, MethodBase.GetCurrentMethod().Name, MethodBase.GetCurrentMethod().DeclaringType.FullName );
            }
        }
        //- METHODS -----------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Returns the actual menu text that will be displayed in the menu.
        /// </summary>
        /// <returns>The actual text of the menu.</returns>
        protected string GetRealText()
        {
            try
            {
                string s = this.Text;
                if ( this.ShowShortcut && this.Shortcut != Shortcut.None )
                {
                    Keys k = ( Keys ) this.Shortcut;
                    s = s + Convert.ToChar( 9 ) + TypeDescriptor.GetConverter( typeof( Keys ) ).ConvertToString( k );
                }
                return s;
            }
            catch ( Exception ex )
            {
                Classes.ErrorHandler.HandleError( ex, MethodBase.GetCurrentMethod().Name, MethodBase.GetCurrentMethod().DeclaringType.FullName );
            }
            return "Error in Get Real Test";
        }
        /// <summary>
        /// Clean up any contained objects that need to be disposed.
        /// </summary>
        /// <param name="disposing">True if dicpose is called from the client, 
        ///   false if called from the finalizer.</param>
        protected override void Dispose( bool disposing )
        {
            try
            {
                base.Dispose( disposing );
                if ( disposing )
                {
                    if ( _font != null )
                        _font.Dispose();
                    if ( _icon != null )
                        _icon.Dispose();
                }
            }
            catch ( Exception ex )
            {
                Classes.ErrorHandler.HandleError( ex, MethodBase.GetCurrentMethod().Name, MethodBase.GetCurrentMethod().DeclaringType.FullName );
            }
        }
        //---------------------------------------------------------------------------------------------------------------------------
    }
}
