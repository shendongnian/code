        //Somewhere in my code:
        foreach (CrystalDecisions.CrystalReports.Engine.Table tbCurrent in rdCurrent.Database.Tables)
		    SetTableLogin(tbCurrent, rdCurrent);
        //My set login method 
		private void SetTableLogin(CrystalDecisions.CrystalReports.Engine.Table table)
		{
			CrystalDecisions.Shared.TableLogOnInfo tliCurrent = table.LogOnInfo;
			tliCurrent.ConnectionInfo.UserID = dbLogin.Username;
			tliCurrent.ConnectionInfo.Password = dbLogin.Password;
			if(dbLogin.Database != null)
				tliCurrent.ConnectionInfo.DatabaseName = dbLogin.Database; //Database is not needed for Oracle & MS Access
			if(dbLogin.Server != null)
				tliCurrent.ConnectionInfo.ServerName = dbLogin.Server;
			table.ApplyLogOnInfo(tliCurrent);
		}
