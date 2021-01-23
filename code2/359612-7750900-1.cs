            IDataReader dr = GetData(sql);
            var dataCollection = new List<string>();
			while(reader.Read())
			{
				dataCollection.Add(reader.GetString(1));
			}
			var extraData = CallWS();
			while(extraData.Read())
			{
				dataCollection.Add(extraData.GetString(1));
			}
			myRepeater.DataSource = dataCollection;
			myRepeater.DataBind();
