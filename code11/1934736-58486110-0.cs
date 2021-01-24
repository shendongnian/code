    MySqlDataAdapter sda = new MySqlDataAdapter();
            sda.SelectCommand = cmdDataBase;
            DataTable dbdataset = new DataTable();
            sda.Fill(dbdataset);
    if(dbdataset.Rows.Count>0)
    {
            var stringArr = dbdataset.Rows[0].ItemArray.Select(x => x.ToString()).ToArray();
    
            idField.Text = stringArr[0];
            oib.Text = stringArr[1];
            name.Text = stringArr[2];
            lastname.Text = stringArr[3];
            place.Text = stringArr[4];
            adress.Text = stringArr[5];
            no.Text = stringArr[6];
            mail.Text = stringArr[7];
    }
    else
    {
    //Do somthing
    }
