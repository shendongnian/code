    public class MyForm : Form
    {
        Dictionary<int, string> _soundFilepaths;
        public void EnableSounds()
        {
            Dictionary<int, string> soundPaths = new Dictionary<int, string>();
            string commandString = "select code_alarme, chemin from alarme";
            using (OdbcConnection conn = new OdbcConnection("DSN=cp1"))
            {
                using (OdbcCommand cmd = new OdbcCommand(commandString, conn))
                {
                    cmd.CommandTimeout = 60;
                    conn.Open();
                    using (OdbcDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            soundPaths.Add(int.Parse(dr[0].ToString()), dr[1].ToString());
                        }
                    }
                }
            }
            this._soundFilepaths = soundPaths;
        }
    }
