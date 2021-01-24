    //AlterColumn("dbo.AspNetUsers", "Id", c => c.String(nullable: false, maxLength: 128));
    AddColumn("dbo.AspNetUsers", "TmpId", c => c.String(nullable: false, maxLength: 128));
    Sql("UPDATE dbo.AspNetUsers SET TmpId = Id");
    DropColumn("dbo.AspNetUsers", "Id");
    AddColumn("dbo.AspNetUsers", "Id", c => c.String(nullable: false, maxLength: 128));
    Sql("UPDATE dbo.AspNetUsers SET Id = TmpId");
    Sql("UPDATE dbo.AspNetUsers SET UserNAme = TmpId");
    DropColumn("dbo.AspNetUsers", "TmpId");
