       GetRecords gr = new gr();
       gr.Request = request;
       gr.VerifyMandatoryParameters();
       gr.SetDefaultValues();
       gr.SetDefaultResponseValues(response);
       gr.GetAllRecords();
