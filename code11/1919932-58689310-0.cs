    public override void Up()
    {
    Sql("CREATE SEQUENCE tbl_seq START WITH 1 INCREMENT BY 1;");
    ..........
    ..........
    CreateTable(
                "dbo.Table_A",
                c => new
                {
                    id = c.Long(nullable: false, identity: false, defaultValueSql: 
                   "NEXT VALUE FOR tbl_seq"),....
    }
     CreateTable(
                "dbo.Table_B",
                c => new
                {
                    id = c.Long(nullable: false, identity: false, defaultValueSql: 
                   "NEXT VALUE FOR tbl_seq"),....
    }
