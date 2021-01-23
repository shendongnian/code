    public IMessageGroups MessageGroups
    {
        get
        {
            return
                MessageGroups.Create(
                    from msg in _messages
                    orderby msg.Type descending
                    group msg by msg.Type);
        }
    }
