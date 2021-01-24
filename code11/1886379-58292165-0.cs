    client.ValidateCertificate += new FtpSslValidation(delegate (FtpClient c, FtpSslValidationEventArgs e) {
    	if (e.PolicyErrors != System.Net.Security.SslPolicyErrors.None){
    		e.Accept = false;
    	}else{
    		e.Accept = true;
    	}
    });
