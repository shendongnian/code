public System.Timers.Timer retransmitTimer;
public TelegramBase SendAndWait(TelegramBase telegram)
{
    CurrentTelegram = telegram;
    using (Timer retransmitTimer = new Timer(RetransmitInterval))
    {
        retransmitTimer.Elapsed += retransmitTimer_Elapsed;
        //Send telegram
        Send(telegram);
        //Start timer
        retransmitTimer.Start();
        //Wait for response
        var response = WaitForResponse(telegram as StandardTelegram);
        //stop timer
        retransmitTimer.Stop();
    }
    return response;
}
