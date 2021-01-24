     public async Task<Members> GetApplicationDetails(int MemberID, int ApplicationID)
        {
            var GetApplication = await _dbContext.Members
                                       .Include(x => x.Members_PersonalInformation)
                                       .Include(x => x.Members_BankRefundDetails)
                                       .Include(x => x.Members_ResidentialAddress)
                                       .Include(x => x.ApplicationFormsSingle).Where(x => x.ApplicationFormsSingle.ID == ApplicationID)
                                       .Include(x => x.ApplicationLogicSingle).Where(x => x.ApplicationLogicSingle.ApplicationFormsID == ApplicationID)
                                       .SingleOrDefaultAsync(f => f.ID == MemberID);
            return GetApplication;
        }
