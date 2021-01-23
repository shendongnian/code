    public T DeSerializeFromString<T>(string data)
            {
                T result;
                StringReader rdr = null;
                try
                {
                    rdr = new StringReader(data);
                    XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
                    result = (T)xmlSerializer.Deserialize(rdr);
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    rdr.Close();
                }
                return result;
            }
