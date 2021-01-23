    var selectedItems = new List<string>();
    foreach( var item in ListBox1.SelectedItems )
    	selectedItems.Add( item.ToString() );
    
    var sql = "Insert dbo.newsletter(newsletter_subject,newsletter_body,newsletter_sentto)"
    	+ "Values(@newsletter_subject, @newsletter_body, @newsletter_sentto)"
    
    badersql.Open();
    using ( qlCommand = new SqlCommand(sql, badersql) )
    {
    	qlCommand.Parameters.AddWithValue("@newsletter_subject", TextBox1.Text);
    	qlCommand.Parameters.AddWithValue("@newsletter_body", TextBox2.Text);
    	qlCommand.Parameters.AddWithValue("@newsletter_sentto", string.Join(',', selectedItems.ToArray()));
    	qlCommand.ExecuteNonQuery();
    };
