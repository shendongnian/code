	SqlCommand cmd = new SqlCommand("Insert into Books (Name,PublishDate,IsInternal) Values (@Name,@PublishDate,@IsInternal)");
	cmd.Parameters.Add(new SqlParameter("@Name", System.Data.SqlDbType.VarChar, 50));
	cmd.Parameters.Add(new SqlParameter("@PublishDate", System.Data.SqlDbType.DateTime));
	cmd.Parameters.Add(new SqlParameter("@IsInternal", System.Data.SqlDbType.Bit));
	cmd.Parameters["@Name"].Value = book.Name;
	cmd.Parameters["@PublishDate"].Value = book.PublishedDate;
	cmd.Parameters["@IsInternal"].Value = book.IsInternal;
