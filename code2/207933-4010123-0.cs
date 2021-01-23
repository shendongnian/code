    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using System.Collections;
    using System.Data.OleDb;
    
    
    namespace WindowsFormsApplication1
    {
        public partial class Form1 : Form
        {
            private string aktuelRapportNR = "";
            string output;
                
            private string connectionName = "Provider=Microsoft.Jet.OLEDB.4.0;"
                + "Data Source=semcqdjh-access 2007.mdb;"
                + "Jet OLEDB:Database Password=;";
            
            
    
               
            public Form1()
            {
                InitializeComponent();
                #region Indlæsning af combobox, med rapport numre
                try
                {
    
                    OleDbConnection Myconnection = null;
                    OleDbDataReader dbReader = null;
    
                    Myconnection = new OleDbConnection(connectionName);
                    Myconnection.Open();
    
                    OleDbCommand cmd = Myconnection.CreateCommand();
                    cmd.CommandText = "SELECT [Rapport nr] FROM AVR";
                    dbReader = cmd.ExecuteReader();
    
                    int rapportNR;
                    while (dbReader.Read())
                    {
                        rapportNR = (int)dbReader.GetInt32(dbReader.GetOrdinal("Rapport nr"));
    
                        comboBox1.Items.Add(rapportNR);
    
                    }
    
                    dbReader.Close();
                    Myconnection.Close();
                    txtStatus.Text = "Indlæsning Fuldført! Vælg venligst en rapport";
                }
                catch (Exception)
                {
    
                    txtStatus.Text = "Indlæsning Fejlet!";
                }
    
    #endregion
            }
    
    
            private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
            {
                aktuelRapportNR = comboBox1.SelectedItem.ToString();
                lblAktuelRapportNR.Text = aktuelRapportNR;
    
                txtStatus.Text = "Du har valgt rapport nr.: " + aktuelRapportNR + "! Klik på export";
            }
    
            private void btnExport_Click(object sender, EventArgs e)
            {
                try
                {
    
                    OleDbConnection Myconnection = null;
                    OleDbDataReader dbReader = null;
    
                    Myconnection = new OleDbConnection(connectionName);
                    Myconnection.Open();
    
                    OleDbCommand cmd = Myconnection.CreateCommand();
                    cmd.CommandText = "SELECT * FROM AVR WHERE [Rapport nr] =" + aktuelRapportNR;
                    dbReader = cmd.ExecuteReader();
    
                    object[] liste = new object[dbReader.FieldCount];
                    if (dbReader.Read() == true)
                    {
    
                        int NumberOfColums = dbReader.GetValues(liste);
    
                        for (int i = 0; i < NumberOfColums; i++)
                        {
                            output += "|" + liste[i].ToString();
                        }
    
                    }
    
                    dbReader.Close();
                    Myconnection.Close();
                    txtStatus.Text = "Export Lykkes! Luk programmet!";
                }
                catch (Exception)
                {
    
                    txtStatus.Text = "Export Fejlet!";
                }
    
                
            }
    
    
        }
    }
