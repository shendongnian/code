    public void SubmitDataEvents(DataPacket parameter)
    {
      foreach (DataEvent dataEvent in parameter.DataEvents)
      {
        var message = dataEvent.ToString();
        Debug.WriteLine(message);
      }
    }
