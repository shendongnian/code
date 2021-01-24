    class Writer<T> : IWriter<T>
    {
        private List<T> items;
    
        public Writer(List<T> items)
        {
            this.items= items;
        }
    
        public List<T> Write()
        {
            using (var ctx = new DatabaseEntities())
            {
                using(var trx = ctx.Database.BeginTransaction())
                {
                    ctx.Item.AddRange(items);
                    rowsAdded = ctx.SaveChanges(); // what is rowsAdded??
                    trx.Commit();
                }
            }
            return items;
        }
    }
