       public class MyTableRepository 
            {
              private IQueryable<MyTableA> tableAEntities;
              public MyTableRepository(MyDbContext  dbContext) 
              {
                  tableAEntities = dbContext.MyTable.Select(t => 
                     new MyTableA 
                    {
                     Id = t.Id, 
                     Field1 = t.Field1, 
                     Field2 = t.Field2, 
                     A = t.A 
                    });
              }
            }
            
