    public object Clone()
    {
        using (MemoryStream stream = new MemoryStream())
        {
            if (this.GetType().IsSerializable)
            {
                BinaryFormatter fmt = new BinaryFormatter();
                fmt.Serialize(stream, this);
                stream.Position = 0;
                return fmt.Deserialize(stream);
            }
            return null;
        }
    }
