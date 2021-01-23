        class PersistState : HiddenFieldPageStatePersister, IStateFormatter
        {
            public PersistState(Page p) : base(p)
            {
                FieldInfo f = typeof(PageStatePersister).GetField("_stateFormatter", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.SetField);
                f.SetValue(this, this);
            }
            object IStateFormatter.Deserialize(string serializedState)
            {
                BinaryFormatter f = new BinaryFormatter();
                using (GZipStream gz = new GZipStream(new MemoryStream(Convert.FromBase64String(serializedState)), CompressionMode.Decompress, false))
                    return f.Deserialize(gz);                    
            }
            string IStateFormatter.Serialize(object state)
            {
                BinaryFormatter f = new BinaryFormatter();
                using (MemoryStream ms = new MemoryStream())
                {
                    using (GZipStream gz = new GZipStream(ms, CompressionMode.Compress, true))
                        f.Serialize(gz, state);
                    return Convert.ToBase64String(ms.ToArray());
                }
            }
        }
