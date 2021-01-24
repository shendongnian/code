void EncryptDB()
{
    using (System.Data.SQLite.SQLiteConnection conn = new System.Data.SQLite.SQLiteConnection("Data Source=Test.db;Password="))
    {
        conn.Open();
        conn.ChangePassword("password");
        conn.Close();
    }
}
void DecryptDB()
{
    using (System.Data.SQLite.SQLiteConnection conn = new System.Data.SQLite.SQLiteConnection("Data Source=Test.db;Password=password"))
    {
        conn.Open();
        conn.ChangePassword("");
        conn.Close();
    }
}
I call the `DecryptDB()` method before I connect to the database with `sqlite-net-pcl` and I call `EncryptDB()` after the connection is closed.
If you are asking why I didn't use `System.Data.Sqlite` instead of `sqlite-net-pcl`, that is because I found that `sqlite-net-pcl` is neat and less code is needed to perform the task which makes it easier to read and document.
@MikeT Thank you for your answer it really guided me and helped me reach this solution.
