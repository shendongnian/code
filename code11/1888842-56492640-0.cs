        string command = "SELECT * FROM Movimentos WHERE [Tipo de Movimento]  = 'Crédito'"; // no need to use IN statement if there is only a check for 1 value
        if (textTipodeMovimento.Text != "")
        {
            command += String.Format(" AND lower([Tipo de Movimento]) LIKE  '%{0}%'", textTipodeMovimento.Text.ToLower());
        }
        Sqldata.DataBind();
