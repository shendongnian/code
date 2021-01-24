    public static IEnumerable<System.Windows.Forms.Control> GetAllControlsOfType(this System.Windows.Forms.Control control, Type type)
            {
                var controls = control.Controls.Cast<System.Windows.Forms.Control>();
    
                return controls.SelectMany(ctrl => GetAllControlsOfType(ctrl, type))
                                          .Concat(controls)
                                          .Where(c => c.GetType() == type);
            }
    private void OnTick(object sender, EventArgs e)
    { 
        var labels = this.GetAllControlsOfType(typeof(Label));
        foreach(var lb in labels){
        lb.BackgroundColor = //Set the BackgroundColor Property here 
        }
    }
