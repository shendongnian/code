        string mediaFormat = "";
        bool video;
        bool audio;
        //---------------------------    populate the detail panel    ---------------------|
        private int PopulateDetailPanel(string SKU) {
            decimal convertedMoney;
            clearDetailPanel();  //  clear out old stuff
            //  now, find all data for this SKU
            if (databaseConn.State == ConnectionState.Closed)
                databaseConn.Open();
            string strSQL = "SELECT * from tMedia where SKU = '" + SKU + "'";
            FbCommand command = new FbCommand(strSQL, databaseConn);
            //  find product type and set flag for later testing
            FbDataReader data = command.ExecuteReader();
            data.Read();  //  only one row is returned
            coProductType.Text = data["ProductType"].ToString();  //  while we're here, might as well set it now
            mediaFormat = data["ProductType"].ToString();
            if (mediaFormat.Substring(0, 6) == "Video ")
                video = true;
            else if (mediaFormat.Substring(0, 7) == "Music: ")
                audio = true;
