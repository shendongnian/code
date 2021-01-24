            foreach (var book in Books) // loop through the books, not the IDs
            {
                SqlCommand tagCommand = new SqlCommand();
                tagCommand.Connection = con.con;
                // in your query, get the ID from the book
                tagCommand.CommandText = "SELECT t.IdTag,t.Name FROM tblTag t LEFT OUTER JOIN tblBookTag bt ON bt.idTag = t.idTag WHERE bt.idBook = @ID";
                tagCommand.Parameters.AddWithValue("@ID", book.IdBook);
                SqlDataReader tagReader = tagCommand.ExecuteReader();
                if (tagReader.HasRows)
                {
                    while (tagReader.Read())
                    {
                        Tag tag = new Tag();
                        var idTag = Convert.ToInt32(tagReader["IdTag"]);
                        var name = tagReader["Name"].ToString();
                        tag.IdTag = idTag;
                        tag.Name = name;
                        // Add the tag to the collection of tags for just that one book.
                        book.Tags.Add(tag);
                    }
                    tagReader.Close();
                }
            }
