    var exams = (from appointment in appointments
                   select new
                        {
                              ((Exam)appointment.CustomFields["Field"]).Id,
                              ((Exam)appointment.CustomFields["Field"]).Name,
                              ((Exam)appointment.CustomFields["Field"]).Date,
                                         ((Exam)appointment.CustomFields["Field"]).Period.StartTime,
                                         ((Exam)appointment.CustomFields["Field"]).Period.EndTime,
                                         Location = ((Exam)appointment.CustomFields["Field"]).Location.Name
                                    });
            
            SetDataSource(exams);
        private void SetDataSource(object exams)
        {          
            scheduleBindingSource.DataSource = exams;
            this.rpTTViewer.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Local;
            this.rpTTViewer.RefreshReport(); 
        }
       
