    string sql = @"
    INSERT into tbl_Meal
        (ExpensesID,MealName,MealPrice,ImageName,Imageblob)
    SELECT
        ExpensesID,@mname,@mprice,@mname,@img 
    FROM tbl_Expenses
    WHERE MealName = @mname";
    using (var conn = new SqlConnection("connection string here"))
    using (var cmd = new SqlCommand(sql, conn))
    {
        //wild guess at column types. Use actual column types/size FROM THE DATABASE
        cmd.Parameters.Add("@mname", SqlDbType.NVarChar, 30).Value = textBox1.Text;  
        cmd.Parameters.Add("@mprice", SQlDbType.Decimal, 18, 8).Value = textBox4.Text;
        //use the size of the column here, not the length of the photo
        cmd.Parameters.Add("@img", SqlDbType.Image, 8000).Value = photo;
        conn.Open();
        cmd.ExecuteNonQuery();
    }
