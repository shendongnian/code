        protected void Viewer_SubmittingParameters(object sender, ReportParametersEventArgs e)
        {
            Microsoft.Reporting.WebForms.ReportParameter userIdParameter =
                new Microsoft.Reporting.WebForms.ReportParameter();
            
            userIdParameter.Name = "UserId";
            userIdParameter.Values.Add(this.Username etc);
            // Add to existing parameters
            e.Parameters.Add(userIdParameter);
        }
