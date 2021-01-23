    string value = "Login";
    MethodInvoker m = () => { login_submit.Text = value; };
    if (InvokeRequired)
    {
        BeginInvoke(m); // I need to pass txt string in some way here.
    }
    else
    {
        Invoke(m); // I need to pass txt string in some way here.
    }
