        public Item GetItem(int id)
        {
            var dc = new DataClasses1DataContext();
            return dc.Items.FirstOrDefault(i => i.Id == id);
        }
