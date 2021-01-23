        public void getRelated()
    {
        string sqlFILL = "SELECT incidentID, postcode AS Postcode, suburb AS Suburb, streetname AS Street, categorycode AS Category, DATE_FORMAT(dateRecorded, '%d/%m/%Y') AS 'Date Recorded', DATE_FORMAT(dateLastModified, '%d/%m/%Y') AS 'Date Last Modified', status AS Status FROM incidentdetails WHERE ((postcode = @postcode) AND (suburb = @suburb) AND (categorycode = @categorycode) AND (status = @status))";
        MySqlConnection mycon = new MySqlConnection(sqlconnection);
        MySqlDataAdapter da = new MySqlDataAdapter();
        mycon.Open();
        MySqlCommand sqlFillRelated = mycon.CreateCommand();
        sqlFillRelated.Parameters.AddWithValue("@postcode", int.Parse(PostcodeTxtBox.Text.ToString()));
        sqlFillRelated.Parameters.AddWithValue("@suburb", SuburbTxtBox.Text.ToString());
        sqlFillRelated.Parameters.AddWithValue("@categorycode", IncidentTypeDropList.Text.ToString());
        sqlFillRelated.Parameters.AddWithValue("@status", "Open");
        sqlFillRelated.CommandText = sqlFILL;
        da.SelectCommand = sqlFillRelated;
        DataSet ds = new DataSet();
        da.Fill(ds);
        g.DataSource = ds;
        g.DataBind();
        mycon.Close();
    }
