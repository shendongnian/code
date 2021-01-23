            var set = new DataSet();
            try
            {
                var content = StringToBytes(s);
                var formatter = new BinaryFormatter();
                using (var ms = new MemoryStream(content))
                {
                    using (var ds = new DeflateStream(ms, CompressionMode.Decompress, true))
                    {
                        set = (DataSet)formatter.Deserialize(ds);                        
                    }
                }
            }
            catch (Exception ex)
            {
                // removed error handling logic!
            }
