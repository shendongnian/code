    var surface = new DesignSurface();
    var host = (IDesignerHost)surface.GetService(typeof(IDesignerHost));
    surface.BeginLoad(typeof(Form));
    var root = (Form)host.RootComponent;
    host.CreateComponent(typeof(BindingSource), "bindingSource1");
    var view = (Control)surface.View;
    view.Dock = DockStyle.Fill;
    view.BackColor = Color.White;
    var splitter = view.Controls.OfType<Splitter>().FirstOrDefault();
    if (splitter != null)
        splitter.BackColor = Color.Red;
    else
    {
        view.ControlAdded += (obj, args) =>
        {
            if (args.Control is Splitter)
                args.Control.BackColor = Color.Red;
        };
    }
    this.Controls.Add(view);
