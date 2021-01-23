    // Loads a users info
        public void loadUserInfo(int usersID = 0)
        {
            if (usersId > 0) this.ID = usersID;
         
            CrystalTech.tblUsersDataTable dsCommon = new CrystalTech.tblUsersDataTable();
            using (tblUsersTableAdapter userAdapter = new tblUsersTableAdapter())
            {
                userAdapter.FillBy(dsCommon, this.ID);
            }
            this.username = dsCommon[0].userName;
            this.company.ID = dsCommon[0].clientID;
            this.company.name = dsCommon[0].ClientName;
            this.isBuyer = bool.Parse(dsCommon[0].isBuyer.ToString());
            this.isClient = bool.Parse(dsCommon[0].isClient.ToString());
            this.isClientPowerUser = bool.Parse(dsCommon[0].powerUser.ToString());
            this.isReportingUser = bool.Parse(dsCommon[0].reportingUser.ToString());
            this.isSupplier = bool.Parse(dsCommon[0].isSupplier.ToString());
            this.isPaperSupplier = bool.Parse(dsCommon[0].isPaperSupplier.ToString());
            this.hasKitView = bool.Parse(dsCommon[0].haskitview.ToString());
        }
   
