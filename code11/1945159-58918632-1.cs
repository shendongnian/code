        public partial class Form1 : Form
        {
            public List<string> files { get; set; }
            public List<string> outputfiles { get; set; }
            
            // these fields are public but not properties, why?
            public int insertNummer;
            public int row_id;
            public Process sp;
            public string ExceptionMessage { get; set; }
            public Form1()
            {
                InitializeComponent();
            }
            private void btnSales_Click(object sender, EventArgs e)
            {
                outputfiles = null;
                files = null;
                sp = null;
                // didn't compile
                if (InformationWindow("Выбирете пожалйста фалы и сохраните в Windows", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.OK)
                {
                    // invert and return
                    if (openFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        foreach (var item in openFileDialog1.FileNames)
                        {
                            files = new List<string>();
                            files.Add(item);
                        }
                    }
                    else
                    {
                        // useless since files is already null at this point
                        files = null;
                    }
                    GetInsertNummer(@"SELECT (SELECT MAX(id) FROM StoredFile) id, MAX(InsertNummer) InsertNummer FROM StoredFile");
                    // useless if return above
                    if (files != null)
                    {
                        for (int i = 0; i < files.Count; i++)
                        {
                            InsertInTable(i);
                            // use ++row_id in FileGetSimple instead
                            row_id++;
                            FileGetSimple(row_id, files[i]);
                        }
                        // doesn't compile
                        InformationWindow("Все в порядке с выбранными файлами?", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                        CreateMessage("smtp.strato.de");
                        MessageBox.Show("success");
                    }
                }
            }
            public DialogResult InformationWindow(string v1, string v2, MessageBoxButtons oKCancel, MessageBoxIcon information)
            {
                // bad practise, rename v1 to caption and v2 to message in method parameter
                string message = v2;
                string caption = v1;
                // unnecessary variable definitions, also weird name "oKCancel" for dynamically assigned MessageBoxButtons that aren't always Ok/Cancel?
                MessageBoxButtons buttons = oKCancel;
                DialogResult result;
                // Displays the MessageBox.
                // return the value directly instead of an unneeded assignment
                return result = MessageBox.Show(message, caption, buttons, information);
            }
            public void CreateMessage(string server)
            {
                using (SmtpClient client = new SmtpClient(server))
                {
                    client.Port = 587;
                    client.EnableSsl = true;
                    client.Credentials = new NetworkCredential("s.dadashev@gebr-naim.de", "");
                    // didn't compile ---
                    MailAddress from = new MailAddress("---", "");
                    MailAddress to = new MailAddress("---", "");
                    MailMessage message = new MailMessage(from, to);
                    message.Subject = "Es funktioniert.";
                    // unnecessary @
                    message.Body = @"Вы получили письмо с вложением";
                    // outputfiles will always only contain a single file --> the loop will only run once, ever!
                    foreach (var item in outputfiles)
                    {
                        // dispose of possibly previously disposed process, not necessary or using statement of sp not necessary
                        if (!sp.HasExited)
                        {
                            sp.Kill();
                        }
                        else
                            sp = null;
                        message.Attachments.Add(new Attachment(item));
                    }
                    InformationWindow("Success", $"Sending an email message to" + to.Address + " by using the SMTP host " + client.Host + ".", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    try
                    {
                        client.Send(message);
                    }
                    catch (Exception ex)
                    {
                        InformationWindow("Exception", ex.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            private void InsertInTable(int i)
            {
                // **** Write BLOB to the Database
                byte[] filebyte = File.ReadAllBytes(files[i]);
                // unnecessary variable declaration (it's only used once), put statement directly in MakeConnection("...")
                string sql = @"insert into StoredFile(FileName,Data,InsertNummer,Date) values(@FileName,@Data,@InsertNummer,@Date)";
                var cmd = MakeConnection(sql);
                // unnecessary variable declarations, parameter1..5 is never used anywhere
                SqlParameter parameter1 = cmd.Parameters.AddWithValue("@FileName", Path.GetFileName(files[i]));
                SqlParameter parameter2 = cmd.Parameters.AddWithValue("@Data", filebyte);
                SqlParameter parameter3 = cmd.Parameters.AddWithValue("@InsertNummer", insertNummer);
                SqlParameter parameter4 = cmd.Parameters.AddWithValue("@Id", row_id);
                SqlParameter parameter5 = cmd.Parameters.AddWithValue("@Date", DateTime.Now);
                cmd.ExecuteNonQuery();
            }
            public bool FileGetSimple(int Identifier, string filePath)
            {
                // why did you start using var instead of the types?
                var pa = Path.Combine(Path.GetTempPath(), Path.GetFileName(filePath));
                var statement = "SELECT Id, Data, FileName FROM StoredFile WHERE Id = @id;";
                var mc = MakeConnection(statement);
                mc.Parameters.AddWithValue("@id", Identifier);
                SqlDataReader reader = mc.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    // the blob field
                    int ndx = reader.GetOrdinal("Data");
                    // that is wrong and not how to read a buffer, read up on how to use buffers/GetBytes correctly!
                    var blob = new Byte[(reader.GetBytes(ndx, 0, null, 0, int.MaxValue))];
                    // oh jeez
                    reader.GetBytes(ndx, 0, blob, 0, blob.Length);
                    reader.Close();
                    try
                    {
                        if (File.Exists(pa))
                        {
                            File.Delete(pa);
                        }
                        using (var fs = new FileStream(pa, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.None))
                        {
                            fs.Write(blob, 0, blob.Length);
                        }
                    }
                    catch (IOException e)
                    {
                        InformationWindow("Warning", e.Message + " Schlie&#223;en Sie diese Datei, um fortzusetzen.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        FileGetSimple(Identifier, filePath);
                    }
                }
                // function is called OpenFiles but only a single file is supplied?
                OpenFiles(pa);
                return true;
            }
            private void OpenFiles(string tempFilePath)
            {
                // what is this even supposed to do?
                // create new process instance
                using (sp = new Process())
                {
                    // then throw away the instance and start a process instead
                    sp = Process.Start(tempFilePath);
                    // then dispose process
                }
                // quiz: has new Process() or Process.Start been disposed by the using statement?
                // every time a file is opened the outputfiles list is re-initialized and a single element is addded?
                // it's never going to contain more than one element!
                outputfiles = new List<string>();
                outputfiles.Add(tempFilePath);
            }
            public void GetInsertNummer(string ins_num_query)
            {
                // using dynamic sql statements but accessing columns statically, how do you guarantee that these columns exist?
                // is there a point in providing a parameter, why can the statement not be inside this function, it never changes!
                var ins_num = MakeConnection(ins_num_query);
                SqlDataReader read_ins_nummer = ins_num.ExecuteReader();
                while (read_ins_nummer.Read())
                {
                    int ins = read_ins_nummer.GetOrdinal("InsertNummer");
                    int ins_id = read_ins_nummer.GetOrdinal("Id");
                    // use previously defined variable "ins" instead of re-executing GetOrdial
                    if (!read_ins_nummer.IsDBNull(read_ins_nummer.GetOrdinal("InsertNummer")))
                    {
                        // insertNummer and row_id is the same, dont' execute GetInt32 twice, use the same value instead!
                        insertNummer = read_ins_nummer.GetInt32(ins);
                        row_id = read_ins_nummer.GetInt32(ins_id);
                        insertNummer++;
                    }
                    else
                    {
                        insertNummer = 1;
                        row_id = 0;
                    }
                }
            }
            public SqlCommand MakeConnection(string sql)
            {
                SqlConnection connection = new SqlConnection("");
                connection.Open();
                // you're using object initializer here, why not everywhere else?
                using (SqlCommand cmd = new SqlCommand() { Connection = connection, CommandText = sql })
                {
                    try
                    {
                        return cmd;
                    }
                    catch (Exception ex)
                    {
                        // this is never used anywhere
                        ExceptionMessage = ex.Message;
                        return cmd;
                    }
                }
            }
            private void exitToolStripMenuItem_Click(object sender, EventArgs e)
            {
                Application.Exit();
            }
        }
