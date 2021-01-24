    private void OnSelectedIndexChanged(object sender, EventArgs e)
    {
        switch (myTabControl.SelectedTab.Name)
        {
            case "foo":
            {
                var o = new foo();
                o.RunCode();
                break;
            }
            case "bar":
            {
                var o = new bar();
                o.RunCode();
                break;
            }
            case "baz":
            {
                var o = new baz();
                o.RunCode();
                break;
            }
        }
    }
