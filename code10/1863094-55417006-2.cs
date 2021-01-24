    private void PipesMessageHandler(string message) 
    {
        if (this.Dispatcher.CheckAccess())
        {
            this.Dispatcher.Invoke(new NewMessageDelegate(PipesMessageHandler), message);
        }
        else
        { 
            string pipeMessage = Convert.DateTime(message);
        }
    }
