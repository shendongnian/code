    private void btnStartAnalysis_Click(object sender, EventArgs e)
    {
    	if(cmbOperations.SelectedItem != null)
    		RunAnalysis<cmbOperations.SelectedItem.Value>();  
    }
    
        private void RunAnalysis<T>()
        {
            	//Checks for the selectedItem in the cmbOpearions dropdown and make call to appropriate functions.  
            	//string assemblyName = cmbOperations.SelectedValue.ToString();  
            	//Assembly assembly = Assembly.LoadFrom(assemblyName);  
            	
            	//Type localType = assembly.GetType("PrimaryKeyChecker.PrimaryKeyChecker");  
              
                	IMFDBAnalyserPlugin analyser = 
                      (IMFDBAnalyserPlugin) Activator.CreateInstance(T);  
                	
    string response = analyser.RunAnalysis(objConnectionString.ConnectionString);  
              
                	//show the response of the the function call  
            	txtPluginResponse.Text = response;  
            }
