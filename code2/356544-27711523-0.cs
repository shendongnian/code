    public partial class MyCustomMigration : DbMigration
    {
        public override void Up()
        {
            this.AlterStoredProcedure("dbo.EditItem", c => new
            {
                ItemID = c.Int(),
                ItemName = c.String(maxLength:50),
                ItemCost = c.Decimal(precision: 10, scale: 4, storeType: "smallmoney")
            }, @" (Stored procedure body SQL goes here) "	
        }
        //...
    }
