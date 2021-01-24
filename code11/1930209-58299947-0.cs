    public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
                CreateDBfile();
                LoadPlayerList();
            }
    
            private void Form1_Load(object sender, EventArgs e)
            {
    
            }
            List<Player> playerDetails = new List<Player>();
            private void LoadPlayerList()
            {
                playerDetails = LoadPlayer();
    
    
                WireUpPlayerList();
            }
    
            private void WireUpPlayerList()
            {
    
                listBox1.DataSource = null;
                listBox1.DataSource = playerDetails;
                listBox1.DisplayMember = "Forename";
            }
            public static List<Player> LoadPlayer()
            {
                using (IDbConnection conn = new SQLiteConnection(LoadConnectionString()))
                {
                    var output = conn.Query<Player>("select * from Player", new DynamicParameters());
                    return output.ToList();
                }
            }
    
            public static void SavePlayer(Player player)
            {
                using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
                {
                    cnn.Execute("insert into Player (Forename, Surname, Position) values (@Forename, @Surname, @Position)", player);
                }
            }
    
    
            private static string LoadConnectionString()
            {
                return "Data Source = MyDatabase.sqlite";
            }
            public void CreateDBfile()
            {
                SQLiteConnection.CreateFile("MyDatabase.sqlite");
    
                SQLiteConnection m_dbConnection = new SQLiteConnection("Data Source=MyDatabase.sqlite");
                m_dbConnection.Open();
    
                string sql = "create table Player ([Forename] NVARCHAR(50) NOT NULL, [Surname] NVARCHAR(50) NOT NULL, [Position] NVARCHAR(50) NOT NULL) ";
    
                SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
                command.ExecuteNonQuery();
                sql = "insert into  Player(Forename,Surname,Position) values('test1','hello','home')";
    
                command = new SQLiteCommand(sql, m_dbConnection);
                command.ExecuteNonQuery();
                sql = "insert into  Player(Forename,Surname,Position) values('test2','hello1','company')";
    
                command = new SQLiteCommand(sql, m_dbConnection);
                command.ExecuteNonQuery();
                sql = "insert into  Player(Forename,Surname,Position) values('test3','hello2','school')";
    
                command = new SQLiteCommand(sql, m_dbConnection);
                command.ExecuteNonQuery();
            }
            
        }
    
        public class Player
        {
            public string Forename { get; set; }
    
            public string Surname { get; set; }
    
            public string Position { get; set; }
    
        }
