    public void DoWork(Form form)
    {
        if (form.InvokeRequired)
        {
            // We're on a thread other than the GUI thread
            form.Invoke(new MethodInvoker(() => DoWork(form)));
            return;
        }
        // Do what you need to do to the form here
        form.Text = "Foo";
    }
