        public static DataTable FilterByEntityID(this DataTable table, int EntityID)
        {
            table.DefaultView.RowFilter = "EntityId = " + EntityID.ToString();
            return table.DefaultView.ToTable();
        }
