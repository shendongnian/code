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
