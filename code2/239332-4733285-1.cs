      private void DeSerilizeQueryFilters(byte[] items)
        {
            BinaryFormatter bf = new BinaryFormatter();
            List<SearchFilterDetails> _list = new List<SearchFilterDetails>();
            try
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    ms.Write(items, 0, items.Length);
                    ms.Position = 0;
                    _list = bf.Deserialize(ms) as List<SearchFilterDetails>;
                }
                foreach (SearchFilterDetails mobj in _list)
                {
                    QueryFilterDetails.Add(mobj);
                }
            }
            catch (Exception ex)
            {
            }
           
        }
