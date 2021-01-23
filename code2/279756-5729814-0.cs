            try
            {
                returnedData = processDataInToOriginalFormat();
                // put code here which should only be executed in
                // case of no exception
            }
            catch (WebException)
            {
                // do what ever is required to handel the problem
                MessageBox.Show("Could not connect to the required Service.");
            }
            // code which should be executed in every case
            WriteBasicTemplate();
