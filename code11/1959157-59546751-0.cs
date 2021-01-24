        public string TesteMetodo(string codPess)
        {
            int codPessNum = 0;
            if (!Int32.TryParse(codPess, out codPessNum))
                return "codPess is not a number";
            var vp = new Classe.validaPessoa();
            try
            {
                using (var conn = new SqlConnection(vp.conString))
                using (var cmd = new SqlCommand("SELECT COUNT(*) FROM teste cliente WHERE cod_pess = @cod_pess", conn))
                {
                    cmd.Parameters.Add("@cod_pess", SqlDbType.Int).Value = codPess;
                    conn.Open();
                    int count = (int)cmd.ExecuteScalar();
                    if (count > 0)
                        return "";
                    return codPess;
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
