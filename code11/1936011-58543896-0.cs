     MW_AppointmentsWithCount CurrentAppointmentsWithLanguage(int PatientID, int languageId, int page, int pageSize)
        {
            MW_AppointmentsWithCount lstAppCount = new MW_AppointmentsWithCount();
            using (MWCoreEntity db = new MWCoreEntity())
            {
                List<MW_Appointments> result = db.MW_Appointments.Where(x => x.PatientID == PatientID && x.Status < 5).ToList();
                foreach (var item in result)
                {
                    item.MW_Consultants = db.MW_Consultants.Where(x => x.UserId == item.ConsultantID && x.LanguageID == languageId).FirstOrDefault();
                }
                lstAppCount.mW_Appointments = result;
                lstAppCount.totalCount = result.Count();
                return result.ToPagedList(page, pageSize);
                
            }
        }
