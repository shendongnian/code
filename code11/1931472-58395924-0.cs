    public partial class CustomMapShapeEditor : UserControl
    {
            public CustomMapShapeEditor()
            {
                InitializeComponent();
            }
    
            public EventHandler Ev_BTN_Pressed ;
            
            private void BTN_Click(object sender, EventArgs e)
            {
                if (Ev_BTN_Pressed != null)
                    Ev_BTN_Pressed (this, e);
            }
    
    }
