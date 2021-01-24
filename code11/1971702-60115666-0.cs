	public void Main()
	{
        // Get the filepath of the file that needs to be encrypted. 
        string filepath = Dts.Variables["Unencrypted_Folder"].Value.ToString() + Dts.Variables["FileNameFound"].Value.ToString();
        // build output path
        string newFilepath = Dts.Variables["$Project::CSV_OutputFolder"].Value.ToString() + Dts.Variables["FileNameFound"].Value.ToString();
        // Get password from SSIS variable
        string encryptionKey = Dts.Variables["EncryptionKey"].ToString();
        // Create an encrypted copy of the file
        Encrypt(filepath, newFilepath, encryptionKey);
        // Close Script Task
        Dts.TaskResult = (int)ScriptResults.Success;
	}
