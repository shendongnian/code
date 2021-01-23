    ...
    EventWaitHandle auto = new EventWaitHandle(false, EventResetMode.ManualReset);
    auto.Reset();
    mySocket.BeginReceiveFrom(arrData, 0, 4, SocketFlags.None, ref EP, new AsyncCallback(ReceiveCallback), auto);
    if (auto.WaitOne(10000, false))
    {
    _log.AppendLine("Message lenght receive success");
    }
    ...
