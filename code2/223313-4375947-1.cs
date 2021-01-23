     private void DeSerilizeQueryFilters(byte[] items)
        {
            BinaryFormatter bf = new BinaryFormatter();
            List<TreeNode> _list = new List<TreeNode>();
            try
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    ms.Write(items, 0, items.Length);
                    ms.Position = 0;
                    _list = bf.Deserialize(ms) as List<TreeNode>;
                    
                }
              
            }
            catch (Exception ex)
            {
            }
          
        }
