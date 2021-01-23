    //Call to create a new user and return the ID
    public static Guid? CreateUser(MyDataContext DB, string UserName, string Password, string Email, string PasswordQuestion, string PasswordAnswer)
    {
    	string salt = GenerateSalt();
    	string password = EncodePassword(Password, salt);
    	string encodedPasswordAnswer = EncodePassword(PasswordAnswer.ToLower(), salt);
    	DateTime dt = DateTime.UtcNow;
    
    	Guid? newUserID = null;
    
    	//res would contain the success or fail code from the stored procedure
    	//0 = success; 1 = fail;
    	int res = DB.aspnet_Membership_CreateUser(	"[My app name]", UserName, password, salt, Email, PasswordQuestion, encodedPasswordAnswer, true, dt, DateTime.Now, 0, 1, ref newUserID);
    	
    	return newUserID;
    }
    
    private static string GenerateSalt()
    {
    	byte[] buf = new byte[16];
    	(new RNGCryptoServiceProvider()).GetBytes(buf);
    	return Convert.ToBase64String(buf);
    }
    private static string EncodePassword(string pass, string salt)
    {
    	byte[] bIn = Encoding.Unicode.GetBytes(pass);
    	byte[] bSalt = Convert.FromBase64String(salt);
    	byte[] bRet = null;
    
    	HashAlgorithm hm = HashAlgorithm.Create("SHA1");
    	if (hm is KeyedHashAlgorithm)
    	{
    		KeyedHashAlgorithm kha = (KeyedHashAlgorithm)hm;
    		if (kha.Key.Length == bSalt.Length)
    		{
    			kha.Key = bSalt;
    		}
    		else if (kha.Key.Length < bSalt.Length)
    		{
    			byte[] bKey = new byte[kha.Key.Length];
    			Buffer.BlockCopy(bSalt, 0, bKey, 0, bKey.Length);
    			kha.Key = bKey;
    		}
    		else
    		{
    			byte[] bKey = new byte[kha.Key.Length];
    			for (int iter = 0; iter < bKey.Length; )
    			{
    				int len = Math.Min(bSalt.Length, bKey.Length - iter);
    				Buffer.BlockCopy(bSalt, 0, bKey, iter, len);
    				iter += len;
    			}
    			kha.Key = bKey;
    		}
    		bRet = kha.ComputeHash(bIn);
    	}
    	else
    	{
    		byte[] bAll = new byte[bSalt.Length + bIn.Length];
    		Buffer.BlockCopy(bSalt, 0, bAll, 0, bSalt.Length);
    		Buffer.BlockCopy(bIn, 0, bAll, bSalt.Length, bIn.Length);
    		bRet = hm.ComputeHash(bAll);
    	}
    	return Convert.ToBase64String(bRet);
    }
