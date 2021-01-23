    async void SendMessages(List<Message> messages)
    {
        foreach (Message message in messages)
        {
            await SendAsync(message);
        }
    }
