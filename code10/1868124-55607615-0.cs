     public static ICreateTableWithColumnSyntax WithAuditColumns(this ICreateTableWithColumnSyntax table)
                {
                    var tt = table.WithColumn("DateCreated").AsDateTime().Nullable()
                        .WithColumn("DateModified").AsDateTime().Nullable()
                        .WithColumn("CreatedBy").AsInt32().Nullable()
                        .WithColumn("ModifiedBy").AsInt32().Nullable();
                    
                    //table.Create.ForeignKey()
                    //    .FromTable("User").ForeignColumn("UserId")
                    //    .ToTable(tableName).PrimaryColumn("CreatedBy");
        
                    //table.Create.ForeignKey()
                    //    .FromTable("User").ForeignColumn("UserId")
                    //    .ToTable(tableName).PrimaryColumn("ModifiedBy");
                    
                    return tt;
                }
