    public bool IsRepeated(string msg, string otherMsg)
    {
        if (otherMsg.Length < msg.Length || otherMsg.Length % msg.Length != 0)
            return false;
    
        for (int i = 0; i < otherMsg.Length; i++)
        {
            if (otherMsg[i] != msg[i % msg.Length])
                return false;
        }
        return true;
    }
