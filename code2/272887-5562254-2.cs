    void UIUpdate1()
    {
        ACount1 = tty.SomeStupidBlockingFunction(ACount1);
        this.BeginInvoke((Action)delegate { txtAuto1.Text = ACount1.ToString(); });
    }
