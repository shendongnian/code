    public static class Core
    {
        public static PatientRow GetCurrentPatient()
        {
            var patient = HttpContext.Current.Items["patient"];
            if (patient == null && HttpContext.Current.User.Identity.IsAuthenticated && HttpContext.Current.User.IsInRole("Patient"))
            {
                using (PatientModel model = new PatientModel())
                {
                    patient = model.Find<PatientRow>(User.CurrentUser.UserID);
                    HttpContext.Current.Items["patient"] = patient;
                }
            }
            return patient;
        }
    }
