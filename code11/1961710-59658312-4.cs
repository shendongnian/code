       private readonly FunctionAlerte  frm1; //readonly is optional (For safety purposes)
    
        public partial class InfosNewAlerte : Form
    {
        public InfosNewAlerte()
        {
            InitializeComponent();
    
        }
        MySqlConnection connection = new MySqlConnection("Server=localhost; database=cap; user id=root; pwd=");
        public DataGridView dataGridViewNewAlerte;
        public DataGridView dataGridViewPaieValide;
    
        //
        // Au Chargement de la page, on recupere les infos de la DATAGRID-NEW-ALERTE et on les affiches sur le nouveau formulaire INFOS NEWS ALERTE FORMULAIRE
        //
        public void InfosNewAlerte_Load(object sender, EventArgs e)
        {
            LblInfo1.Text = AlerteControl.id;
            LblPrenom1.Text = AlerteControl.prenom;
            LblAmiLocal1.Text = AlerteControl.amilocal;
            LblSBN1.Text = AlerteControl.sbn;
            LblExtension1.Text = AlerteControl.extension;
            LblCheckIn1.Text = AlerteControl.checkin;
            LblPaieHT1.Text = AlerteControl.paieht;
            LblPaieTTC1.Text = AlerteControl.paiettc;
        }
    
        //
        // En cliquant sur le bouton valider de cette page alors vous envoyez cette paie a la partie finance et la SUPPRIME de New Alerte
        //
    
        public void BtnValidationPaie_Click(object sender, EventArgs e)
        {
            try
            {
                string InsertPaie = "INSERT INTO paievalide(Prenom,AmiLocal,Extension,SBN,CheckIn,PaieHT,PaieTTC) VALUES('" + LblPrenom1.Text + "','" + LblAmiLocal1.Text + "', '" + LblExtension1.Text + "', '" + LblSBN1.Text + "', '" + LblCheckIn1.Text + "', '" + LblPaieHT1.Text + "', '" + LblPaieTTC1.Text + "')";
                MySqlFunctionEmploye.ExecuteQuery(InsertPaie);
    
                string deleteQuery = "DELETE FROM newpaie WHERE ID =" + LblInfo1.Text;
                MySqlFunctionEmploye.ExecuteQuery(deleteQuery);
    
    
                AlerteControl AlerteControl = new AlerteControl();
              //  AlerteControl.MajDatagrids(); // Appel de la methode de MISE A JOUR DES DATAGRIDVIEWS   
    
    
                
               
                frm1.RefreshDataGridViewNewPaie(dataGridViewNewAlerte);
                frm1.RefreshDataGridViewPaieValide(dataGridViewPaieValide);
                Console.WriteLine("pas d'erreur");
    
               this.Close();
            }
            catch(MySqlException exception)
            {
                MessageBox.Show(exception.ToString());
            }
        }
    }
