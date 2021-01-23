    namespace CDKatalog
    {
        public partial class KorisnickoUputstvo : System.Web.UI.Page
        {
            string[] izvodjac = new string[20];
            string[] nazivAlbuma = new string[20];
            string[] zanr = new string[20];
            string[] godinaIzdavanja = new string[20];
            string[] izdavackaKuca = new string[20];
            string[] slikaOmota = new string[20];
            protected void Page_Load(object sender, EventArgs e)
            {
                for (int i = 1990; i <= 2019; i++)
                {
                    DropDownList2.Items.Add(i.ToString());
                }
                StreamReader sr = File.OpenText(Server.MapPath(@"\textFajl\katalog.txt"));
                string sadrzaj = sr.ReadToEnd();
                int brojac = 1;
                int j = 0;
                for (int i = 0; i < sadrzaj.Length; i++)
                {
                    if (sadrzaj[i] == '^') { j++; brojac++; }
                    else if (sadrzaj[i] == '|')
                    {
                        brojac++;
                    }
                    else if (brojac % 6 == 1)
                    {
                        izvodjac[j] = izvodjac[j] + sadrzaj[i];
                    }
                    else if (brojac % 6 == 2)
                    {
                        nazivAlbuma[j] = nazivAlbuma[j] + sadrzaj[i];
                    }
                    else if (brojac % 6 == 3)
                    {
                        zanr[j] = zanr[j] + sadrzaj[i];
                    }
                    else if (brojac % 6 == 4)
                    {
                        godinaIzdavanja[j] = godinaIzdavanja[j] + sadrzaj[i];
                    }
                    else if (brojac % 6 == 5)
                    {
                        izdavackaKuca[j] = izdavackaKuca[j] + sadrzaj[i];
                    }
                    else if (brojac % 6 == 0)
                    {
                        slikaOmota[j] = slikaOmota[j] + sadrzaj[i];
                    }
                }
            }
            protected void Button1_Click(object sender, EventArgs e)
            {
                
                DataTable dt = new DataTable();
                dt.Clear();
              
                dt.Columns.Add("Izvodjac", typeof(string));
                dt.Columns.Add("Naziv Albuma", typeof(string));
                dt.Columns.Add("Zanr", typeof(string));
                dt.Columns.Add("Godina Izdavanja", typeof(string));
                dt.Columns.Add("Izdavacka Kuca", typeof(string));
        
                    string pomoc = "";
                    for (int i = 1; i < 7; i++)//OVDE TREBA MENJATI BROJ
                    {
                       for (int c = 0; c < TextBox1.Text.Length; c++)
                        {
                            if (TextBox1.Text[c] == izvodjac[i][c + 2])
                            {
                                pomoc = pomoc + TextBox1.Text[c];
                            }
                            else {
                                pomoc = "";
                                break;
                            }
                           
                        }
                       if (pomoc != "")
                       {
                           
                           dt.Rows.Add(izvodjac[i], nazivAlbuma[i], zanr[i], godinaIzdavanja[i], izdavackaKuca[i]);
                       }
                    }
                    Label1.Text = nazivAlbuma[1][1].ToString();
                  
                    GridView1.DataSource = dt;
                    GridView1.DataBind();          
            }
            protected void Button2_Click(object sender, EventArgs e)
            {
                DataTable dt = new DataTable();
                dt.Clear();
                
                dt.Columns.Add("Izvodjac", typeof(string));
                dt.Columns.Add("Naziv Albuma", typeof(string));
                dt.Columns.Add("Zanr", typeof(string));
                dt.Columns.Add("Godina Izdavanja", typeof(string));
                dt.Columns.Add("Izdavacka Kuca", typeof(string));
                string pomoc = "";
                for (int i = 1; i < 7; i++)
                {
                    for (int c = 0; c < TextBox2.Text.Length; c++)
                    {
                        if (TextBox2.Text[c] == nazivAlbuma[i][c])
                        {
                            pomoc = pomoc + TextBox2.Text[c];
                        }
                        else
                        {
                            pomoc = "";
                            break;
                        }
                    }
                    if (pomoc != "")
                        dt.Rows.Add(izvodjac[i], nazivAlbuma[i], zanr[i], godinaIzdavanja[i], izdavackaKuca[i]);
                }
                GridView1.DataSource = dt;
                GridView1.DataBind();      
            }
            protected void Button5_Click(object sender, EventArgs e)
            {
                DataTable dt = new DataTable();
                dt.Clear();
               
                dt.Columns.Add("Izvodjac", typeof(string));
                dt.Columns.Add("Naziv Albuma", typeof(string));
                dt.Columns.Add("Zanr", typeof(string));
                dt.Columns.Add("GodinaIzdavanja", typeof(string));
                dt.Columns.Add("Izdavacka Kuca", typeof(string));
                string pomoc = "";
                for (int i = 1; i < 7; i++)
                {
                    for (int c = 0; c < TextBox3.Text.Length; c++)
                    {
                        if (TextBox3.Text[c] == izdavackaKuca[i][c])
                        {
                            pomoc = pomoc + TextBox3.Text[c];
                        }
                        else
                        {
                            pomoc = "";
                            break;
                        }
                    }
                    if (pomoc != "")
                        dt.Rows.Add(izvodjac[i], nazivAlbuma[i], zanr[i], godinaIzdavanja[i], izdavackaKuca[i]);
                }
                GridView1.DataSource = dt;
                GridView1.DataBind(); 
            }
            protected void Button3_Click(object sender, EventArgs e)
            {
                DataTable dt = new DataTable();
                dt.Clear();
              
                dt.Columns.Add("Izvodjac", typeof(string));
                dt.Columns.Add("Naziv Albuma", typeof(string));
                dt.Columns.Add("Zanr", typeof(string));
                dt.Columns.Add("Godina Izdavanja", typeof(string));
                dt.Columns.Add("Izdavacka Kuca", typeof(string));
                for (int i = 0; i < 7; i++)
                {
                    if (DropDownList1.SelectedValue == zanr[i]) {
                        dt.Rows.Add(izvodjac[i], nazivAlbuma[i], zanr[i], godinaIzdavanja[i], izdavackaKuca[i]);
                    }
                }
                GridView1.DataSource = dt;
                GridView1.DataBind(); 
            }
            protected void Button4_Click(object sender, EventArgs e)
            {
                DataTable dt = new DataTable();
                dt.Clear();
              
                dt.Columns.Add("Izvodjac", typeof(string));
                dt.Columns.Add("NazivAlbuma", typeof(string));
                dt.Columns.Add("Zanr", typeof(string));
                dt.Columns.Add("Godina Izdavanja", typeof(string));
                dt.Columns.Add("Izdavacka Kuca", typeof(string));
                for (int i = 0; i < 7; i++)
                {
                    if (DropDownList2.SelectedValue == godinaIzdavanja[i])
                    {
                        dt.Rows.Add(izvodjac[i], nazivAlbuma[i], zanr[i], godinaIzdavanja[i], izdavackaKuca[i]);
                    }
                }
                GridView1.DataSource = dt;
                GridView1.DataBind(); 
            }
        }
    }
