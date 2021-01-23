    bool msg_match = user.LastMessages.Any(x => String.Equals(x, msg, StringComparison.OrdinalIgnoreCase));
    if (msg_match)
    {
        // punish user
        user.LastMessages.Clear();
    }
    else
    {
        // some way to remove oldest message and leave only the 3 newest messages
        user.LastMessages.AddFirst(mensagem);
        if (user.LastMessages.Count > 3)
            user.LastMessages.RemoveLast();
    }
