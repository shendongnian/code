    private static bool Is_Member_Of_Channel(string channel_name, int user_id)
    {
        //Status Values
        //Creator
        //Member
        //Left
        var t = Bot.GetChatMemberAsync(channel_name, user_id);
        if (t.Result.Status.ToString() == "Left")
            return false;
        return true;
    }
