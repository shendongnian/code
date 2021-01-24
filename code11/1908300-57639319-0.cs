    TLInputMediaContact contact = new TLInputMediaContact()
    {
        FirstName = FirstName,
        LastName = LastName,
        PhoneNumber = PhoneNumber 
    };
    TLRequestSendMedia req = new TLRequestSendMedia()
    {
        Media = contact,
        Peer = new TLInputPeerUser() { UserId = AnotherTelegramAccountUserID.Id },
        RandomId = UniqueNumber_ToPreventDuplicateMessages,
    };
    await clientAlt.SendRequestAsync<TLUpdates>(req);
