     public void InsertDataBase(MyEntity entity)
        {
            repository.Database.ExecuteSqlCommand("sp_mystored " +
                    "@param1, @param2"
                     new SqlParameter("@param1", entity.property1),
                     new SqlParameter("@param2", entity.property2));
        }
 
