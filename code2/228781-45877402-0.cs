    private string CalculateHash( SecureString securePasswordString, string saltString )
    {
    	IntPtr unmanagedString = IntPtr.Zero;
    	try
    	{
    		unmanagedString = Marshal.SecureStringToGlobalAllocUnicode( securePasswordString );
    		byte[] passwordBytes = Encoding.UTF8.GetBytes( Marshal.PtrToStringUni( unmanagedString ) );
    		byte[] saltBytes = Encoding.UTF8.GetBytes( saltString );
    		byte[] passwordPlusSaltBytes = new byte[ passwordBytes.Length + saltBytes.Length ];
    		Buffer.BlockCopy( passwordBytes, 0, passwordPlusSaltBytes, 0, passwordBytes.Length );
    		Buffer.BlockCopy( saltBytes, 0, passwordPlusSaltBytes, passwordBytes.Length, saltBytes.Length );
    		HashAlgorithm algorithm = new SHA256Managed();
    		return Convert.ToBase64String( algorithm.ComputeHash( passwordPlusSaltBytes ) );
    	}
    	finally
    	{
    		if( unmanagedString != IntPtr.Zero )
    			Marshal.ZeroFreeGlobalAllocUnicode( unmanagedString );
    	}
    }
    
    string passwordSalt = "INSERT YOUR CHOSEN METHOD FOR CONSTRUCTING A PASSWORD SALT HERE";
    string passwordHashed = CalculateHash( securePasswordString, passwordSalt );
    string confirmPasswordHashed = CalculateHash( secureConfirmPasswordString, passwordSalt );
    if( passwordHashed == confirmPasswordHashed )
    {
    	// Both matched so go ahead and persist the new password.
    }
    else
    {
    	// Strings don't match, so communicate the failure back to the UI.
    }
