    //subscribe
    wbPrzegladarka.FrameLoadEnd += FrameLoad;
    public async void FrameLoad(object sender, EventArgs e)
    {
        if (args.Frame.IsMain)
        {
            await args.Frame.EvaluateScriptAsync("alert('MainFrame finished loading');");
            //Unsubscribe 
            wbPrzegladarka.FrameLoadEnd -= FrameLoad;
        }
    }
