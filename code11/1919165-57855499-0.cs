    public void Importar()
    {
        StreamReader leitor = new StreamReader(txtNome.Text);
        String linha = String.Empty;
    
        while (!leitor.EndOfStream)
        {
            linha = leitor.ReadLine();
    
            String[] dados = linha.Split(';');
            string nome = dados[0];
            string cpf = dados[1];
            string idunidade = dados[2];
    
    
    		using(Conexao c = new Conexao())
    		{
    			c.Abrir();
    			using(MySqlCommand cmd = new MySqlCommand("select * from colaborador where CPF = @CPFC"))
    			{
    				cmd.Parameters.Add(new MySqlParameter("@CPFC", cpf));
    				using(MySqlDataReader leia = c.Pesquisar(cmd))
    				{
    					if (leia.Read())
    					{
    						using(MySqlCommand updateCmd = new MySqlCommand("update colaborador set Nome = @NomeC, idUnidade = @idUnidadeC where CPF = @CPFC"))
    						{
    							updateCmd.Parameters.Add(new MySqlParameter("@NomeC", nome));
    							updateCmd.Parameters.Add(new MySqlParameter("@idUnidadeC", idunidade));
    							updateCmd.Parameters.Add(new MySqlParameter("@CPFC", cpf));
    							c.Executar(updateCmd);                   
    						}
    						else
    						{                    
    							using(MySqlCommand insertCmd = new MySqlCommand("insert into colaborador values (default, @NomeC, @CPFC, @idUnidadeC"))
    							{
    								insertCmd.Parameters.Add(new MySqlParameter("@NomeC", nome));
    								insertCmd.Parameters.Add(new MySqlParameter("@idUnidadeC", idunidade));
    								insertCmd.Parameters.Add(new MySqlParameter("@CPFC", cpf));
    								c.Executar(insertCmd);
    							}
    						}
    					}
    				}                
    			}
    		}
        }
    }
