    public partial class Form3 : Form 
    {        
        string var; 
        int ID1; 
     
    private void button1_Click(object sender, EventArgs e) 
    { 
        ID1 = int.Parse(textBox1.Text); 
        SqlConnection cn = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\asp\Desktop\DatabasesPractice\DatabasesPractice\soccer.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True"); 
        SqlCommand dataCommand = new SqlCommand("SELECT Name FROM team WHERE ID = @ID1", cn); 
        dataCommand.Parameters.AddWithValue("@ID1", ID1); // this is the new line of code
 
        cn.Open(); 
        var = Convert.ToString(dataCommand.ExecuteScalar()); 
        label3.Text = var; 
 
    } 
