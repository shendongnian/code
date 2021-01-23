    SvnUpdateArgs ua = new SvnUpdateArgs();
    ua.Notify += delegate(object sender, SvnNotifyEventArgs e)
            {
                Console.Write(e.Action);
                Console.WriteLine(e.FullPath);
            };
