    using System;
    using System.ComponentModel.Design;
    using System.Drawing;
    using System.Windows.Forms;
    using System.Windows.Forms.Design;
    using System.Windows.Forms.Design.Behavior;
    public class MyTLP : TableLayoutPanel
    {
        private IDesignerHost designerHost;
        private BehaviorService behaviorService;
        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            if (DesignMode && Site != null)
            {
                designerHost = Site.GetService(typeof(IDesignerHost)) as IDesignerHost;
                behaviorService = designerHost?.GetService(typeof(BehaviorService))
                    as BehaviorService;
                if (behaviorService != null)
                {
                    var adorner = new Adorner();
                    behaviorService.Adorners.Insert(0, adorner);
                    adorner.Glyphs.Add(new MyTLPGlypg(behaviorService, this));
                }
            }
        }
    }
    class MyTLPGlypg : Glyph
    {
        Control control;
        BehaviorService behaviorSvc;
        public MyTLPGlypg(BehaviorService behaviorSvc, Control control) :
            base(new MyBehavior())
        {
            this.behaviorSvc = behaviorSvc;
            this.control = control;
        }
        public override Rectangle Bounds
        {
            get
            {
                var edge = behaviorSvc.ControlToAdornerWindow(control);
                var h = 30;
                return new Rectangle(edge.X, edge.Y - h, control.Size.Width, h);
            }
        }
        public override Cursor GetHitTest(Point p)
        {
            //Uncomment if you want to attach a specific behavior
            //if (Bounds.Contains(p)) return Cursors.Hand;
            return null;
        }
        public override void Paint(PaintEventArgs pe)
        {
            pe.Graphics.FillRectangle(Brushes.Orange, Bounds);
        }
    }
    class MyBehavior : Behavior
    {
        public override bool OnMouseUp(Glyph g, MouseButtons button)
        {
            //Do something and return true, meand eventhandled
            return true;
        }
    }
