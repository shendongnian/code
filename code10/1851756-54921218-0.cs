    public class tbTest
            {
                [PrimaryKey, AutoIncrement]
                public Int32 Auto_Sequence { get; set; }
                public byte[] MyImageLogo { get; set; }
            }
    
    Pay attention in the byte declaration. This is your "Blob".  Now let's save it in the local database  
    
      var db = MyConnection();
    
    where MyConnection is the connect that you are doing with your database.
    
       private SQLite.SQLiteConnection MyConnection()
                {
                    var db = new SQLite.SQLiteConnection(app.dbpath); //you already know the path of the database I'm just keeping it in a global variable.
                    return db;  
                }
    
      //insert
    
                        db.RunInTransaction(() =>
                           {
    
                               db.Insert(new Myapplication.App.tbTest()
                               {
                                         MyImageLogo = MyByteArray variable
                               });
                              
    
    db.Dispose();
