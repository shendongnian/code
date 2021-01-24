CID         Category
----------- --------------------------------------------------
          1 Pen
          2 Pencil
SID         CID         SubCategory
----------- ----------- --------------------------------------------------
          1           1 BallPoint
          2           2 HB
ID          SID         CID         Item
----------- ----------- ----------- --------------------------------------------------
          1           1           1 Matadoor
          2           2           2 Natraz
Category       SubCategory                                        Item
-------------- -------------------------------------------------- -----------------------
Pen            BallPoint                                          Matadoor
Pencil         HB                                                 Natraz
Here is the code that worked for me.
FormLoad:
C#
private void Form1_Load(object sender, EventArgs e)
 {
        string query2 = "select * from Category";
        string maincon = ConfigurationManager.ConnectionStrings["MyConn"].ConnectionString;
        SqlCommand com1 = new SqlCommand(query2, con);
        con.Open();
        SqlDataAdapter adp1 = new SqlDataAdapter(com1);
        DataTable dt1 = new DataTable();
        adp1.Fill(dt1);
        comboBox1.ValueMember = "CID";
        comboBox1.DisplayMember = "Category";
        comboBox1.DataSource = dt1;
        comboBox3.Enabled = false;
        comboBox2.Enabled = false;
        
 }
First ComboBox:
C#
private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
 {
       if (comboBox1.SelectedValue != null)
       {
       
          string query2 = "select * from SubCategory where CID=@CID";
          SqlCommand com1 = new SqlCommand(query2, con);
          com1.Parameters.AddWithValue("@CID", comboBox1.SelectedValue);
          SqlDataAdapter adp1 = new SqlDataAdapter(com1);
          DataTable dt1 = new DataTable();
          adp1.Fill(dt1);
          comboBox2.ValueMember = "SID";
          comboBox2.DisplayMember = "SubCategory";
          comboBox2.DataSource = dt1;
          comboBox3.Enabled = false;
          comboBox2.Enabled = true;
       }
 }
Second ComboBox:
C#
private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
 {
      if (comboBox2.SelectedValue != null)
      {
          string query2 = "select * from Item where SID=@ID";
          SqlCommand com1 = new SqlCommand(query2, con);
          com1.Parameters.AddWithValue("@SID", comboBox2.SelectedValue);
          SqlDataAdapter adp1 = new SqlDataAdapter(com1);
          DataTable dt1 = new DataTable();
          adp1.Fill(dt1);
          comboBox3.ValueMember = "ID";
          comboBox3.DisplayMember = "Item";
          comboBox3.DataSource = dt1;
          con.Close();
          comboBox3.Enabled = true;
          comboBox2.Enabled = true;
       }
 }
`
Third ComboBox:
C#
private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
 {
       textBox1.Text = Convert.ToString(comboBox3.SelectedValue);
 }
**Note:** I have tried this with Access database. Sql should work with above code. Please let me know if anyone find any problem using this piece of code.
Happy Coding.
Thanks to @vikschool.
