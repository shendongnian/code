    void GetInitialData()
    {
        EventHandler<EventArgs> handler;
        handler = (sender, e) =>
        {
            if(e.Message.Id == guid)
            {
                FillInfo();
                Communicator.NewMessage -= handler;
            }
        };
        string guid = Guid.NewGuid().ToString();
        Communicator.NewMessage += handler;;
        Communicator.SendMessage(new Message(stuff, guid));
    }
