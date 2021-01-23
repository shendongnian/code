    using (SqlConnection conn=new SqlConnection(sql_string)) {
        conn.Open();
        SqlCommand command=new SqlCommand(
            sql_query,
            conn
        );
        Int32 quizid=((Int32?)command.ExecuteScalar()) ?? 0;
    }
