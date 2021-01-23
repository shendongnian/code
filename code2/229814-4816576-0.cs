data.Status.ToString()
:
    GsmCommMain comm = new GsmCommMain(port, baundRate, timeout);
    //.... Other code may goes here
    // Read all SMS messages from the storage
        DecodedShortMessage[] messages = comm.ReadMessages(PhoneMessageStatus.All, 
        PhoneStorageType.Sim );// Or PhoneStorageType.Phone
        foreach (DecodedShortMessage message in messages)
            {
              if (((SmsPdu)message.Data) is SmsStatusReportPdu)
              {
                    //HERE WE'LL GET THE STATUS REPORT
                    SmsStatusReportPdu data = (SmsStatusReportPdu)message.Data;
                    //Recipient: data.RecipientAddress
                    //Status: data.Status.ToString()
                    //Timestamp: data.DischargeTime.ToString()
                    //Message ref (ID of the sent sms from the mobile): data.MessageReference.ToString()
              
          }
        }
