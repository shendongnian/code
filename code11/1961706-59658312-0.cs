    public void BtnValidationPaie_Click(object sender, EventArgs e)
        {
            try
            {
                string InsertPaie = "INSERT INTO paievalide(Prenom,AmiLocal,Extension,SBN,CheckIn,PaieHT,PaieTTC) VALUES('" + LblPrenom1.Text + "','" + LblAmiLocal1.Text + "', '" + LblExtension1.Text + "', '" + LblSBN1.Text + "', '" + LblCheckIn1.Text + "', '" + LblPaieHT1.Text + "', '" + LblPaieTTC1.Text + "')";
                MySqlFunctionEmploye.ExecuteQuery(InsertPaie);
    
                string deleteQuery = "DELETE FROM newpaie WHERE ID =" + LblInfo1.Text;
                MySqlFunctionEmploye.ExecuteQuery(deleteQuery);
    
    
                AlerteControl AlerteControl = new AlerteControl();
                AlerteControl.MajDatagrids(); // **Calling the method to update DATAGRIDVIEWS**   
    
                //FunctionAlerte FunctionAlerte = new FunctionAlerte();
                //FunctionAlerte.RefreshDataGridViewNewPaie(dataGridViewNewAlerte); **This is actually the function i call in my method above. If i call the function right away i got an error saying my datagrid is Null, which can't be null all the cells are filled up.**
                //FunctionAlerte.RefreshDataGridViewPaieValide(dataGridViewPaieValide);
                this.Close();
    
                Console.WriteLine("pas d'erreur");
              
              MyFunction(); //this where you need to call it
            }catch(MySqlException exception)
            {
                MessageBox.Show(exception.ToString());
            }
        }
