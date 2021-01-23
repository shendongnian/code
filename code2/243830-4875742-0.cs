        public Item GetItem(int id)
        {
            var se = new SampleEntities();
            return se.Items.FirstOrDefault(i => i.Id == id);
        }
