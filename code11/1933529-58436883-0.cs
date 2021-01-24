    public partial class Form1 : Form
    {
        HttpClient _httpClient = new HttpClient();
        public Form1()
        {
            InitializeComponent();
            dtgId.AllowUserToAddRows = false;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            AllId();
        }
        public void AllId()
        {//method to populate the DataGridView
            try
            {
                using (SqlDataAdapter da = new SqlDataAdapter("SELECT id, cellphone FROM clients GROUP BY id", "constr"))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dt.Columns.Add("Choose", typeof(bool)); //will become a checkbox column in the grid
                    dtgId.DataSource = dt;
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private async void SendSms(string id, string number, string message)
        {
            var values = new Dictionary<string, string>
            {
                { "api", "1" },
                { "usario", "user" },
                { "clave", "pass" },
                { "separadorcampos", "tab" },
                { "bloque",  $"{id}\t{number}\t{message}\n" }
            };
            var content = new FormUrlEncodedContent(values);
            var response = await _httpClient.PostAsync("uri", content);
            var responseString = await response.Content.ReadAsStringAsync();
            //do whatever with response...
        }
        private void GoButton_Click(object sender, DataGridViewCellEventArgs e)
        {
            DataTable dt = dtgId.DataSource as DataTable;
            foreach (DataRow ro in dt.Rows) //iterate the table
            {
                if (ro.Field<bool>("Choose")) //if ticked by user
                    SendSms(ro.Field<string>("ID"), ro.Field<string>("Cellphone"), "hello, this is my message"); //send the sms
            }
           
        }
    }
