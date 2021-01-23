    public static class AttrDictX
    {
        public static AttrDict ToAttrDict(this object obj)
        {
            if (obj == null)
                throw new ArgumentNullException("obj");
            var ans = new AttrDict();
            foreach (var prop in obj.GetType().GetProperties())
            {
                if (prop.CanRead)
                    ans.Add(prop.Name, prop.GetValue(obj, null));
            }
            return ans;
        }
    }
