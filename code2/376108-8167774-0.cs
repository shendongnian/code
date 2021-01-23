        Dictionary<Guid, Form> dic = new Dictionary<Guid, Form>();
        public Form ShowForm(Guid userId)
        {
            Form form;
            if (!dic.TryGetValue(userId, out form))
            {
                form = new Form();
                dic.Add(userId, form);
            }
            return form;
        }
