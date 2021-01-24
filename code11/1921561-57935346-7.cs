        // xml
        string xml = File.ReadAllText(labelTextBoxBrowserControl1.Text);
        // Create a new instance of a 'ResponsesParser' object.
        ResponsesParser parser = new ResponsesParser();
                
        // load the response
        Response response = parser.ParseResponse(xml);
        // if the response object exists
        if (response != null)
        {   
            // set each property from the response
            EntityLineNumberControl.Text = response.EntitylineNumber.ToString();
            EntityUIDControl.Text = response.EntityUID;
            StatusCodeControl.Text = response.StatusCode;
            EntityMarkControl.Text = response.EntityMark;
        }
