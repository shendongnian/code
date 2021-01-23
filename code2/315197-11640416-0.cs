    static public C DeepCopyChangingNamespace<O,C>(O original)
    {
        using (MemoryStream ms = new MemoryStream())
        {
            Serializer.Serialize(ms, original);
            ms.Position = 0;
            C c = Serializer.Deserialize<C>(ms);
            return c;
        }
    }
