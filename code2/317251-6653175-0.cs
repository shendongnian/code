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
    override void OnLoad()
    {
        IEnumerable tasks = AsyncLoadUI();
        MethodInvoker msg;
        msg = delegate { tasks.MoveNext(); BeginInvoke(msg); };
        msg();
    }
