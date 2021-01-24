    var dialogs = (TLDialogs)await client.GetUserDialogsAsync(limit: 50);
    TLChat chat = dialogs.Chats.OfType<TLChat>().FirstOrDefault();
    int userId = 0; // User ID To Delete
    var request = new TLRequestGetFullChat() { ChatId = chat.Id };
    var fullChat = await client.SendRequestAsync<TeleSharp.TL.Messages.TLChatFull>(request);
    var participants = (fullChat.FullChat as TeleSharp.TL.TLChatFull).Participants as TLChatParticipants;
    var p = participants.Participants.FirstOrDefault();
    if (p is TLChatParticipant)
    {
        var participant = p as TLChatParticipant;
        Console.WriteLine($"\t{participant.UserId}");
        userId = participant.UserId;
    }
    else if (p is TLChatParticipantAdmin)
    {
        var participant = p as TLChatParticipantAdmin;
        Console.WriteLine($"\t{participant.UserId}**");
        userId = participant.UserId;
    }
    else if (p is TLChatParticipantCreator)
    {
        var participant = p as TLChatParticipantCreator;
        Console.WriteLine($"\t{participant.UserId}**");
        userId = participant.UserId;
    }
    var deleteRequest = new TLRequestDeleteChatUser()
    {
        ChatId = chat.Id,
        UserId = new TLInputUser()
        {
            UserId = userId
        }
    };
    await client.SendRequestAsync<TLUpdates>(deleteRequest);
View Sample code for looking up channels, participants, peers, chats etc from [here](https://github.com/ppanhoto78/TLSharpMod)
