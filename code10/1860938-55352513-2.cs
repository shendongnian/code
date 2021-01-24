    void BackGroundProcedure(object sender, DoworkEventArgs e)
    {
        // if you know that the backgroundworker is started with parameters:
        MyParameters parameters = (MyParameters)e.Argument;
        // do you work, regularly check if cancellation is requested:
        while (!e.Cancel)
        {
            ...
            // only if progress reports are needed: report some progress, not too often!
            MyProgressParams progressParams = new MyProgressParams(...);
            this.ReportProgress(..., progressParams);
        }
        // if here, the thread is requested to cancel
        // if needed report some result:
        e.Result = ...;
    }
