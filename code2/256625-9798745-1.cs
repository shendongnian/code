    using System.Data.SqlClient;
    
    using System.Drawing;
    
    using System.Data;
    
    using System.IO;
    
    using System.Drawing.Imaging;
    
    
    public void Save_Image(Object sender, EventArgs e)
    {
    
        // Create a byte[] from the input file
    
        int len = Upload.PostedFile.ContentLength;
        byte[] pic = new byte[len];
        Upload.PostedFile.InputStream.Read (pic, 0, len);
    
        // Insert the image into the database
    
        SqlConnection connection = new
     SqlConnection (@"server=abc\.SQLEXPRESS;database=Storage;uid=sa;pwd=sa");
    
        try
        {
            connection.Open ();
            SqlCommand cmd = new SqlCommand ("insert into Image " 
              + "(Picture) values (@pic)", connection);
    
            cmd.Parameters.Add ("@pic", pic);
            cmd.ExecuteNonQuery ();
    
        }
        finally 
        {
            connection.Close ();
        }
    }
    
        we are only storing byte-image into table name"Image"
     which contains only one column. 
     Storing byte-image into database consume a lot of database-size
     for large image-storing and retrieving specific image from database
     using search  takes longer time for processing.This causes 
    low performance and storage problem.
