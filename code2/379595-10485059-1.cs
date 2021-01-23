        public override void Up()
        {
            CreateIndex("TableName", "ColumnName");
        }
        
        public override void Down()
        {
            DropIndex("TableName",new[] {"ColumnName"});
        }
