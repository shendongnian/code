    [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")] 
    public class TabButtonDesigner : System.Windows.Forms.Design.ControlDesigner
    {
        ShowTabGlyph myGlyph = null;
        Adorner myAdorner;
        public TabButtonDesigner()
        {
        }
        public override void Initialize(IComponent component)
        {
            base.Initialize(component);
            // Add the custom set of glyphs using the BehaviorService. 
            // Glyphs live on adornders.
            myAdorner = new Adorner();
            BehaviorService.Adorners.Add(myAdorner);
            myGlyph = new ShowTabGlyph(BehaviorService, Control);
            myGlyph.Callback = () =>
            {
                ((StratoTabButton)this.Control).ShowMyTab();
            };
            myAdorner.Glyphs.Add(myGlyph);
        }
        class ShowTabGlyph : Glyph
        {
            Control control;
            BehaviorService behaviorSvc;
            public Action Callback
            {
                get;
                set;
            }
            public ShowTabGlyph(BehaviorService behaviorSvc, Control control) :
                base(new ShowTabBehavior())
            {
                this.behaviorSvc = behaviorSvc;
                this.control = control;
            }
            public override Rectangle Bounds
            {
                get
                {
                    // Create a glyph that is 10x10 and sitting
                    // in the middle of the control.  Glyph coordinates
                    // are in adorner window coordinates, so we must map
                    // using the behavior service.
                    Point edge = behaviorSvc.ControlToAdornerWindow(control);
                    Size size = control.Size;
                    Point center = new Point(edge.X + (size.Width / 2),
                        edge.Y + (size.Height / 2));
                    Rectangle bounds = new Rectangle(
                        center.X - 5,
                        center.Y - 5,
                        10,
                        10);
                    return bounds;
                }
            }
            public override Cursor GetHitTest(Point p)
            {
                // GetHitTest is called to see if the point is
                // within this glyph.  This gives us a chance to decide
                // what cursor to show.  Returning null from here means
                // the mouse pointer is not currently inside of the glyph.
                // Returning a valid cursor here indicates the pointer is
                // inside the glyph, and also enables our Behavior property
                // as the active behavior.
                if (Bounds.Contains(p))
                {
                    return Cursors.Hand;
                }
                return null;
            }
            public override void Paint(PaintEventArgs pe)
            {
                // Draw our glyph. It is simply a blue ellipse.
                pe.Graphics.DrawEllipse(Pens.Blue, Bounds);
            }
            // By providing our own behavior we can do something interesting
            // when the user clicks or manipulates our glyph.
            class ShowTabBehavior : Behavior
            {
                public override bool OnMouseUp(Glyph g, MouseButtons button)
                {
                    //MessageBox.Show("Hey, you clicked the mouse here");
                    //this.
                    ShowTabGlyph myG = (ShowTabGlyph)g;
                    if (myG.Callback != null)
                    {
                        myG.Callback();
                    }
                    return true; // indicating we processed this event.
                }
            }
        }
    }
    [DesignerAttribute(typeof(TabButtonDesigner))]
    public class MyTabButton : System.Windows.Forms.Button
    {
        // The attribute will assign the custom designer to the TabButton
        // and after a rebuild the button contains a centered blue circle
        // that acts at design time like the button in runtime does ...
        
        // ...
    }
