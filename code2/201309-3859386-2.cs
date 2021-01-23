    public IEnumerable<Foo> MessageGroups
    {
        get
        {
            return
                (from msg in _messages
                 orderby msg.Type descending
                 group msg by msg.Type
                 select new Foo { Elements = g, Key = g.Key }      
                );
        }
    }
