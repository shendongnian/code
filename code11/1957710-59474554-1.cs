    // create
    SQLiteConnection.CreateFile("MyDatabase.sqlite");
    SQLiteConnection m_dbConnection = new SQLiteConnection("Data Source=MyDatabase.sqlite");
    m_dbConnection.Open();
    string sql = "create table highscores (name varchar(20), score int)";
    SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
    command.ExecuteNonQuery();
    sql = "insert into highscores (name, score) values ('Me', 9001)";
    command = new SQLiteCommand(sql, m_dbConnection);
    command.ExecuteNonQuery();// read
    SQLiteCommand sqlCom = new SQLiteCommand("Select * From highscores", m_dbConnection);
    SQLiteDataReader sqlDataReader = sqlCom.ExecuteReader();
    int i = 1;
    while (sqlDataReader.Read())
    {
        listBox1.Items.Add(i);
        listBox1.Items.Add(sqlDataReader.GetValue(0));
        listBox1.Items.Add(sqlDataReader.GetValue(1));
        i++;
    }
    m_dbConnection.Close();
