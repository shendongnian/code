    while (true)
    {
        string data = RelayBoard_Port.ReadTo("\r\n");
        if (data == "ok")
        {
            controller.SetMessage("Done Process");
            break;
        }
        else { controller.SetProgress(Int32.Parse(data)); }
    }
