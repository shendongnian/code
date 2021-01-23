    private static byte[] getDocument(int documentId)
    {
        using (SqlConnection cn = new SqlConnection("..."))
        using (SqlCommand cm = cn.CreateCommand())
        {
            cm.CommandText = @"
                SELECT DocumentData
                FROM   Document
                WHERE  DocumentId = @Id";
            cm.Parameters.AddWithValue("@Id", documentId);
            cn.Open();
            return cm.ExecuteScalar() as byte[];
        }
    }
