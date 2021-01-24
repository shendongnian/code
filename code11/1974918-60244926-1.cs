    //This gets the chatbots response for each message
    chatbot.MainUser.ResponseReceived += async (sender, args) =>
    {
        msgModel.Text = args.Response.Text;
        msgModel.User = App.ChatBot;
        await Task.Delay(1500);
        Messages.Add(msgModel);
    };
