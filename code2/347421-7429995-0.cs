       public void patientUpdate()
        {
            hospitalSQLEntities db = new hospitalSQLEntities();
            string formpatientid = Request.Params["patientid"];
            patient mypatient = null;
            try
            {
                mypatient = db.patients.Single(u =>
                    u.patientid.Equals(formpatientid));
            }
