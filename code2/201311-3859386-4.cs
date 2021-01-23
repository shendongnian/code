    public IEnumerable<Foo> MessageGroups
    {
        get
        {
            return
                (from msg in _messages
                 orderby msg.Type descending
                 group msg by msg.Type
                 select new Foo { Messages = g, MessageType = g.Key }      
                );
        }
    }
