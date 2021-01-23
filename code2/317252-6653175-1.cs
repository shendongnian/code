    IEnumerable AsyncLoadUI()
    {
        var p = new Panel();
        Controls.Add(p);
        yield return null;
        for( int i = 0; i < 50; ++i ) {
            var txt = new TextBox();
            p.Controls.Add(txt);
            yield return null;
        }
    }
    override void OnLoad(EventArgs e)
    {
        IEnumerable tasks = AsyncLoadUI();
        MethodInvoker msg;
        msg = delegate { if (tasks.MoveNext()) BeginInvoke(msg); };
        msg();
    }
