    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Data;
    using System.Windows.Documents;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    using System.Windows.Navigation;
    using System.Windows.Shapes;
    using System.Data.SqlClient;
    using System.Data;
    
    namespace WpfApplication1
    {
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
            }
    
            private void btnAdd_Click(object sender, RoutedEventArgs e)
            {
                SqlConnection conn = new SqlConnection(@"Data Source=WKS09\SQLEXPRESS;Initial Catalog = StudentManagementSystem;Integrated Security=True");
                SqlCommand insert = new SqlCommand("insert into dbo.StudentRegistration(ID, Name,Age,DateOfBirth,Email,Comment) values(@ID, @Name,@Age,@DateOfBirth,@mail,@comment)", conn);
                insert.Parameters.AddWithValue("@ID", textBox1.Text);
                insert.Parameters.AddWithValue("@Name", textBox2.Text);
                insert.Parameters.AddWithValue("@Age", textBox3.Text);
                insert.Parameters.AddWithValue("@DateOfBirth", textBox4.Text);
                insert.Parameters.AddWithValue("@mail", textBox5.Text);
                insert.Parameters.AddWithValue("@comment", textBox6.Text);
    
                if (textBox1.Text == string.Empty)
                {
                    MessageBox.Show("ID Cannot be Null");
                    return;
                }
                else if (textBox2.Text == string.Empty)
                {
                    MessageBox.Show("Name Cannot be Null");
                    return;
                }
    
    
                try
                {
                    conn.Open();
                    insert.ExecuteNonQuery();
                    MessageBox.Show("Register done !");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error" + ex.Message);
                    conn.Close();
                }
            }
    
            private void btnRetrive_Click(object sender, RoutedEventArgs e)
            {
                bool temp = false;
                SqlConnection con = new SqlConnection("server=WKS09\\SQLEXPRESS;database=StudentManagementSystem;Trusted_Connection=True");
                con.Open();
                SqlCommand cmd = new SqlCommand("select * from dbo.StudentRegistration where ID = '" + textBox1.Text.Trim() + "'", con);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    textBox2.Text = dr.GetString(1);
                    textBox3.Text = dr.GetInt32(2).ToString(); 
                    textBox4.Text = dr.GetDateTime(3).ToString();
                    textBox5.Text = dr.GetString(4);
                    textBox6.Text = dr.GetString(5);
                    temp = true;
                }
                if (temp == false)
                    MessageBox.Show("not found");
                con.Close();
            }
    
            private void btnClear_Click(object sender, RoutedEventArgs e)
            {
                SqlConnection connection = new SqlConnection("Data Source=WKS09\\SQLEXPRESS;Initial Catalog = StudentManagementSystem;Integrated Security=True");
                string sqlStatement = "DELETE FROM dbo.StudentRegistration WHERE ID = @ID";
                try
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand(sqlStatement, connection);
                    cmd.Parameters.AddWithValue("@ID", textBox1.Text);
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Done");
                }
                finally
                {
                    Clear();
                    connection.Close();
                }
            }
    
            public void Clear()
            {
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
            }
        }
    }
