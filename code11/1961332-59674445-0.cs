    using System;
    
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Reflection;
    using System.Runtime.CompilerServices;
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
    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    
    namespace comboboxapp1
    {
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
               public MainWindow()
            { 
                InitializeComponent();
                this.DataContext = new SimpleMath();
                 Fillcombobox();
            }
                private void MainWindow_Load(object sender, EventArgs e)
                {
    
                }
                public void Fillcombobox()
                {
                SqlConnection con = new SqlConnection("Data Source=LEAN-22\\SQLEXPRESS;Initial Catalog=LUAT;Integrated Security=True") ;
    
                    string sql = " select * from comboboxnew ";
                    SqlCommand cmd = new SqlCommand(sql, con);
                    SqlDataReader myreader;
                    try
                    {
                        con.Open();
                        myreader = cmd.ExecuteReader();
                        while (myreader.Read())
                        {
                            string sname = myreader.GetInt32(0).ToString();
                            comboBox1.Items.Add(sname);
    
                        }
    
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
    
                    }
                }
            public class SimpleMath : INotifyPropertyChanged
            {
                private int _no1;
    
                public int No1
                {
                    get => _no1;
                    set
                    {
                        _no1 = value;
                        OnPropertyChanged();
                        CalculateSum();
                        OnPropertyChanged("A");
                    }
                }
                private int _txtcode;
    
                public int Txtcode
                {
                    get => _txtcode;
                    set
                    {
                        _txtcode = value;
                        OnPropertyChanged();
                        CalculateSum();
                        OnPropertyChanged("A");
                    }
                }
                private int _txtpieces;
    
                public int Txtpieces
                {
                    get => _txtpieces;
                    set
                    {
                        _txtpieces = value;
                        OnPropertyChanged();
                        CalculateSum();
                        OnPropertyChanged("A");
    
                    }
                }
                private int _txtlayers;
    
                public int Txtlayers
                {
                    get => _txtlayers;
                    set
                    {
                        _txtlayers = value;
                        OnPropertyChanged();
                        CalculateSum();
                        OnPropertyChanged("A");
    
                    }
                }
                private int _txtproductionpieces;
    
                public int Txtproductionpieces
                {
                    get => _txtproductionpieces;
                    set
                    {
                        _txtproductionpieces = value;
                        OnPropertyChanged();
                        CalculateSum();
                        OnPropertyChanged("A");
    
                    }
                }
                private int _txtseccond;
    
                public int Txtseccond
                {
                    get => _txtseccond;
                    set
                    {
                        _txtseccond = value;
                        OnPropertyChanged();
                        CalculateSum();
                        OnPropertyChanged("A");
    
                    }
                }
                private int a;
                public int A
                {
                    get => a;
                    set
                    {
                        a = value;
                        OnPropertyChanged();
                    }
                }
                private void CalculateSum()
                {
                    A = Txtcode + Txtlayers + Txtpieces;
                }
                public event PropertyChangedEventHandler PropertyChanged;
                public void OnPropertyChanged([CallerMemberName()] string propertyName = null)
                {
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
                }
            }
            private void ComboBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
            {
               
    
                SqlConnection con = new SqlConnection("Data Source=LEAN-22\\SQLEXPRESS;Initial Catalog=LUAT;Integrated Security=True");
                //  string sql = " select * from comboboxnew where code = '" + comboBox1.Text+ "';";
                string sql = " select * from comboboxnew where code = '" + comboBox1.SelectedItem + "';";
               
                //Console.WriteLine(comboBox1.Text);
                //MessageBox.Show(comboBox1.Text);
                SqlCommand cmd = new SqlCommand(sql, con); 
                SqlDataReader myreader; 
                try
                {
                    
                    con.Open();
                    myreader = cmd.ExecuteReader();
                    while (myreader.Read())
                    {
                      
                        string code = myreader.GetInt32(0).ToString();
                        string pieces = myreader.GetInt32(1).ToString();
                        string layers = myreader.GetInt32(2).ToString();
                        string productionpieces = myreader.GetInt32(3).ToString();
                        string seccond = myreader.GetInt32(4).ToString();
    
                        txtcode.Text = code;
                        
                        txtpieces.Text = pieces;
                   
                        txtlayers.Text = layers;
                
                        txtproductionpieces.Text = productionpieces;
                      
                        txtseccond.Text = seccond;
    
                    
    
    
                }
    
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
    
            }
    
        }
    }  
