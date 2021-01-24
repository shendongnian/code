     private void btnSearch_Click(object sender, EventArgs e)
        {
            dataGridReceitas.Rows.Clear();
            string receitas = @"receitas.txt";
            if (File.Exists(receitas))
            {
                StreamReader sr2 = File.OpenText(receitas);
                string linha2 = "";
                int x = 0;
                while ((linha2 = sr2.ReadLine()) != null)
                {
                    string[] campos2 = linha2.Split(';');
                    if(comboBoxCategorias.SelectedItem.ToString() == campos2[2])
                    {
                        if((txtTitulo.Text == "") || (txtIngredientes.Text == ""))
                        {
                            dataGridReceitas.Rows.Add(1);
                            dataGridReceitas[0, x].Value = campos2[0];
                            dataGridReceitas[1, x].Value = campos2[1];
                            dataGridReceitas[2, x].Value = campos2[2];
                            dataGridReceitas[3, x].Value = campos2[3];
                            x++;
                        }
                       
                    }
                    
                }
                sr2.Close();
            }
        }
