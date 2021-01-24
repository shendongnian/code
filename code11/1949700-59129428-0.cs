    class MessageComparer : IEqualityComparer<Message>
    {
    	public bool Equals(Message x, Message y)
    	{
    		return (x.SenderId == y.SenderId || x.SenderId == y.RecipientId)
    		&& (x.RecipientId == y.RecipientId || x.RecipientId == y.SenderId); // i guess you can go as specific as you like here, depending on your requirements
    	}
    
    	public int GetHashCode(Message obj)
    	{
    		return (obj.SenderId ^ obj.RecipientId).GetHashCode();
    	}
    }
