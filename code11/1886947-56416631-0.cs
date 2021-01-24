    public dbtest(){
            sqlconnection = new SqlConnection(ConnectionString);
            Query =
                "SELECT questions.id as qid, questions.question as qq FROM dbo.questions; ";
            sqlcommand = new SqlCommand(Query, sqlconnection);
            sqlconnection.Open();
            SqlDataReader sdr = sqlcommand.ExecuteReader();
            while (sdr.Read())
            {
                int quiz_id;
                bool quiz_id1 = Int32.TryParse(sdr["qid"].ToString(), out quiz_id);
                sqlconnection = new SqlConnection(ConnectionString);
                Query =
                "SELECT id, question_id, answer, is_correct FROM dbo.question_answers WHERE question_id = " + quiz_id + "  ; ";
                sqlcommand = new SqlCommand(Query, sqlconnection);
                sqlconnection.Open();
                SqlDataReader answr = sqlcommand.ExecuteReader();
                questions[quiz_id, 0] = sdr["qq"].ToString();
                var ii = 1;
                while (answr.Read())
                {
                    questions[quiz_id, ii] = answr["answer"].ToString();
                    ii++;
                }
            }
        }
 
