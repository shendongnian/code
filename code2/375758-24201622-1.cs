    var whatever = new[]
                {
                    new
                    {
                        Id = 1,
                        Name = "Bacon",
                        Foo = false
                    },
                    new
                    {
                        Id = 2,
                        Name = "Sausage",
                        Foo = false
                    },
                    new
                    {
                        Id = 3,
                        Name = "Egg",
                        Foo = false
                    },
                };
    
    			//use the ToDataTable extension method to populate an ado.net DataTable
    			//from your IEnumerable<T> using the property definitions.
    			//Note that if you want to pass the datatable to a Table-Valued-Parameter,
    			//The order of the column definitions is significant.
                var dataTable = whatever.ToDataTable(
                    whatever.Property(r=>r.Id).AsPrimaryKey().Named("item_id"),
                    whatever.Property(r=>r.Name).AsOptional().Named("item_name"),
                    whatever.Property(r=>r.Foo).Ignore()
                    );
