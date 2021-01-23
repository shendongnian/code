    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.ComponentModel;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Drawing.Text;
    using System.Windows.Forms;
    using LollipopUIControls.UIManagers;
    namespace Gamasis.Apps.Controls
    {
    public class FloatingButton : Button
    {
        public FloatingButton()
        {
            SetStyle((ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor | ControlStyles.UserPaint), true);
            DoubleBuffered = true;
            Size = new Size(50, 50);
            BackColor = Color.Transparent;
            SF.Alignment = StringAlignment.Center;
            SF.LineAlignment = StringAlignment.Center;
            AnimationTimer.Tick += new EventHandler(AnimationTick);
        }
        #region  Variables
        Timer AnimationTimer = new Timer { Interval = 1 };
        FontManager font = new FontManager();
        StringFormat SF = new StringFormat();
        Rectangle StringRectangle;
        bool Focus = false;
        int margintop = 0, marginleft = 0, marginright = 0, marginBottom = 0;
        int xx;
        int yy;
        float SizeAnimation = 0;
        float SizeIncNum;
        string fontcolor = "#FAFAFA";
        string Backcolor = "#039BE5";
        Color EnabledBGColor;
        Color EnabledBorderColor;
        Color StringColor;
        Color DisabledBGColor = ColorTranslator.FromHtml("#B0BEC5");
        Color DisabledStringColor = ColorTranslator.FromHtml("#FAFAFA");
        Color NonColor = ColorTranslator.FromHtml("#e3e5e7");
        Image bGImage = null;
        #endregion
        #region  Properties
        [Category("Custom")]
        public string BGColor
        {
            get { return Backcolor; }
            set
            {
                Backcolor = value;
                Invalidate();
            }
        }
        [Category("Custom")]
        public string FontColor
        {
            get { return fontcolor; }
            set
            {
                fontcolor = value;
                Invalidate();
            }
        }
        [Browsable(false)]
        public Font Font
        {
            get { return base.Font; }
            set { base.Font = value; }
        }
        [Browsable(false)]
        public Color ForeColor
        {
            get { return base.ForeColor; }
            set { base.ForeColor = value; }
        }
        [Category("Custom")]
        public Image BGImage
        {
            get { return bGImage; }
            set { bGImage = value; }
        }
        ImageSizeLevel bGimgSize = ImageSizeLevel.peque2;
        public ImageSizeLevel BGimgSize
        {
            get { return bGimgSize; }
            set { bGimgSize = value; }
        }
        #endregion
        #region Events
        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            EnabledBGColor = Color.FromArgb(30, ColorTranslator.FromHtml(BGColor));//StringColor);
            EnabledBorderColor = Color.FromArgb(20, ColorTranslator.FromHtml(BGColor));//StringColor);
            Refresh();
        }
        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            EnabledBGColor = ColorTranslator.FromHtml(BGColor);
            EnabledBorderColor = ColorTranslator.FromHtml(BGColor);
            Refresh();
        }
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            EnabledBGColor = Color.FromArgb(30, StringColor);
            Refresh();
            xx = e.X;
            yy = e.Y;
            Focus = true;
            AnimationTimer.Start();
            Invalidate();
        }
        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            Focus = false;
            AnimationTimer.Start();
            Invalidate();
        }
        protected override void OnTextChanged(System.EventArgs e)
        {
            base.OnTextChanged(e);
            Invalidate();
        }
        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            //StringRectangle = new Rectangle(3, 0, Width - 6, Height - 6);
        }
        #endregion
        protected override void OnResize(System.EventArgs e)
        {
            base.OnResize(e);
            //SizeIncNum = Width / 34;
            SizeIncNum = Width / 10;
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            var G = e.Graphics;
            #region Default rectangle
            //G.SmoothingMode = SmoothingMode.HighQuality | SmoothingMode.AntiAlias;
            //G.Clear(Parent.BackColor);
            //StringColor = ColorTranslator.FromHtml(fontcolor);
            //var BG = DrawHelper.CreateRoundRect(1, 1, Width - 3, Height - 3, 1);
            //Region region = new Region(BG);
            //G.FillPath(new SolidBrush(Enabled ? EnabledBGColor : Color.White), BG);
            //G.DrawPath(new Pen(Enabled ? EnabledBorderColor : Color.White), BG);
            //G.SetClip(region, CombineMode.Replace);
            ////The Ripple Effect
            //G.FillEllipse(new SolidBrush(Color.FromArgb(30, StringColor)), xx - (SizeAnimation / 2), yy - (SizeAnimation / 2), SizeAnimation, SizeAnimation);
            //G.DrawString(Text, font.Roboto_Medium10, new SolidBrush(Enabled ? StringColor : DisabledStringColor), R, SF);
            #endregion
            #region Circle
            //G.SmoothingMode = SmoothingMode.AntiAlias;
            //G.Clear(BackColor);
            //GraphicsPath bgbtn = new GraphicsPath();
            //bgbtn.AddEllipse(0, 0, Width - 5, Height - 5);
            //GraphicsPath bgShadow = new GraphicsPath();
            //bgShadow.AddEllipse(0, 0, Width - 2, Height - 2);
            //G.FillPath(new SolidBrush(NonColor), bgShadow);
            //G.DrawPath(new Pen(NonColor), bgShadow);
            //G.FillPath(new SolidBrush(Color.DeepSkyBlue), bgbtn);            
            //G.DrawPath(new Pen(Color.DeepSkyBlue), bgbtn);
            #endregion
            ///----------------------------
            G.SmoothingMode = SmoothingMode.AntiAlias;
            G.Clear(Parent.BackColor);
            StringColor = ColorTranslator.FromHtml(fontcolor);
            //var BG = DrawHelper.CreateRoundRect(1, 1, Width - 3, Height - 3, 1);
            //Círculo principal
            GraphicsPath bgbtn = new GraphicsPath();
            bgbtn.AddEllipse(2, 0, Width - 6, Height - 6);
            //Círculo para la sombra
            GraphicsPath bgShadow = new GraphicsPath();
            bgShadow.AddEllipse(2, 4, Width - 6, Height - 6);
            // se dibuja la sombra
            G.FillPath(new SolidBrush(NonColor), bgShadow);
            G.DrawPath(new Pen(NonColor), bgShadow);
            //sedibuja el círculo principal sobre la sombra
            G.FillPath(new SolidBrush(Enabled ? ColorTranslator.FromHtml(BGColor) : DisabledBGColor), bgbtn);
            G.DrawPath(new Pen(Enabled ? ColorTranslator.FromHtml(BGColor) : DisabledBGColor), bgbtn);
            // Se da a la región forma de círculo/elipse
            Region region = new Region(bgbtn);//BG);
            G.SetClip(region, CombineMode.Replace);
            //The Ripple Effect
            if (Enabled)
                G.FillEllipse(new SolidBrush(Color.FromArgb(30, EnabledBGColor)), xx - (SizeAnimation / 2), yy - (SizeAnimation / 2), SizeAnimation, SizeAnimation);
            StringRectangle = new Rectangle((int)bgbtn.GetBounds().Location.X, (int)bgbtn.GetBounds().Location.Y,
                (int)bgbtn.GetBounds().Size.Width, (int)bgbtn.GetBounds().Size.Height);
            G.DrawString(Text, font.Roboto_Medium15, new SolidBrush(Enabled ? StringColor : DisabledStringColor), StringRectangle, SF);
            if (bGImage != null)
            {
                float imgX = 0, imgY = 0;
                imgY = (bgbtn.GetBounds().Size.Height - (int)bGimgSize) / 2;
                imgX = ((bgbtn.GetBounds().Size.Width - (int)bGimgSize) + 2) / 2;
                G.DrawImage(bGImage, imgX, imgY, (float)bGimgSize, (float)bGimgSize);
            }
        }
        protected void AnimationTick(object sender, EventArgs e)
        {
            if (Focus)
            {
                if (SizeAnimation < Width + 250)
                {
                    SizeAnimation += SizeIncNum;
                    this.Invalidate();
                }
            }
            else
            {
                if (SizeAnimation > 0)
                {
                    SizeAnimation = 0;
                    this.Invalidate();
                }
            }
        }
        public enum ImageSizeLevel
        {
            peque = 12, peque1 = 24, peque2 = 32,
            maso = 48, maso1 = 56, maso2 = 64,
            grande = 72, grande1 = 86, grande2 = 96,
            monstruo = 128, monstruo1 = 256, monstruo2 = 512
        }
    }
}
