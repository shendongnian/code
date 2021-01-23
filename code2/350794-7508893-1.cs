    public bool IsRepeated(string msg, string otherMsg)
    {
        if (otherMsg.Length < msg.Length || otherMsg.Length % msg.Length != 0)
            return false;
    
        bool isRepeated = Enumerable.Range(0, otherMsg.Length / msg.Length)
                                    .Select(i => otherMsg.Substring(i * msg.Length, msg.Length))
                                    .All(x => x == msg);
        return isRepeated;
    }
