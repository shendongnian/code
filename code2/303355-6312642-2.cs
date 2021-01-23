    private static string GetErrorMessage(int error)
    {
    	string result = "";
    	StringBuilder stringBuilder = new StringBuilder(256);
    	int num = SafeNativeMethods.FormatMessage(12800, NativeMethods.NullHandleRef, error, 0, stringBuilder, stringBuilder.Capacity + 1, IntPtr.Zero);
    	if (num != 0)
    	{
    		int i;
    		for (i = stringBuilder.Length; i > 0; i--)
    		{
    			char c = stringBuilder[i - 1];
    			if (c > ' ' && c != '.')
    			{
    				break;
    			}
    		}
    		result = stringBuilder.ToString(0, i);
    	}
    	else
    	{
    		result = "Unknown error (0x" + Convert.ToString(error, 16) + ")";
    	}
    	return result;
    }
