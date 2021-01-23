    namespace Components {
        [ToolboxData("<{0}:MyControl runat=server></{0}:MyControl>")]
        public class MyControl : WebControl, INamingContainer {
            // todo: add controls that are created dynamically
            private GridView gridView;
            public MyControl () {
                Initialize();
            }
        
            [Browsable(false)]
            public override ControlCollection Controls {
                get { EnsureChildControls(); return base.Controls; }
            }
            protected override void OnLoad(EventArgs e) {
                // todo: attach event listeners for instance
                base.OnLoad(e);
            }
            protected override void CreateChildControls() {
                Initialize();
            }
            protected override void Render(HtmlTextWriter writer) {
                 if (DesignMode) {
                     // If special design mode rendering
                     return;
                 }
                 base.Render(writer);
            }
            /// This is where the controls are created
            private void Initialize() {
                base.Controls.Clear();
                // todo: Create all controls to add, even those "added later"
                // if something is generated but should not be shown,
                // set its Visible to false until its state is changed
                Label exampleLabel = new Label();
                exampleLabel.Visible = false; // like so
                if (gridView == null) { gridView = new GridView(); }
                base.Controls.Add(exampleLabel);
                base.Controls.Add(gridView);
            }
        }
    }
