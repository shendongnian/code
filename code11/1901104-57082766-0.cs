while (reader.Read())
    {                       
       ulong MessageID = (ulong)reader.GetInt64(0);                     
       var message = (RestUserMessage)await Context.Channel.GetMessageAsync(MessageID);
       await message.ModifyAsync(x => x.Content = "Test [Edited].");
    }
