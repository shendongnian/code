        public OneToManyPart<TChild> KeyColumn(string columnName)
        {
            Key(ke =>
            {
                ke.Columns.Clear();
                ke.Columns.Add(columnName);
            });
            return this;
        }
