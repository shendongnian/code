    private void VraboteniPoOpstini_Load(object sender, EventArgs e)
    {
       try
       {
           // add a "using System.Data.SqlClient" to your file, to make this simpler
           ad = new SqlDataAdapter("Select * from tbl_PersonalniPodatoci ", con);
           DataTable dt = new DataTable();
           ad.Fill(dt);
           //fill combobox
           cbOpstini.DataSource = dt;
           cbOpstini.DisplayMember = "Opstina";
           cbOpstini.ValueMember = "Sifra";
       }
       catch (Exception ex)
       {
          MessageBox.Show(ex.Message, "ГРЕШКА", MessageBoxButtons.OK);
       }   
    }
