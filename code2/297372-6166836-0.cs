    ArrayList l = new ArrayList();
    foreach (Control c in Controls){
        if (ShouldKeepControl(c))
            l.Add(c);
        else
            UnhookEvents(c);
    }
    SuspendLayout();
    Controls.Clear();
    Controls.AddRange((Control[])l.ToArray(typeof(Control)));
    ResumeLayout();
