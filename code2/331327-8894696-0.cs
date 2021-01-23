    var cntrlCollections = GetAll(this,typeof(TextBox));
           foreach (Control ctrl in cntrlCollections)
            {
               
                if (ctrl is TextBox)
                {
                    ctrl.Text = " ";
                }
            }      
    public IEnumerable<Control> GetAll(Control control, Type type)
        {
            var controls = control.Controls.Cast<Control>();
            return controls.SelectMany(ctrl=>GetAll(ctrl,type)).Concat(controls).Where
                   (c=>c.GetType() ==type);
        }
