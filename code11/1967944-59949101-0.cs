    catch (Exception err){
        Dispatcher.BeginInvoke((Action)(() => {
            pConsole.AppendText(err.Message);
            pConsole.AppendText(err.StackTrace);
            pConsole.ScrollToEnd();
        }));
        return;
    }
