    public static bool isControlInPageOruserControl(Control uc)
    {
    	bool inPage = uc.NamingContainer is Page;
    	if (inPage) {
    		return true;
    	} else if (uc.NamingContainer is UserControl) {
    		return false;
    	} else {
    		return isControlInPageOruserControl(uc.NamingContainer);
    	}
    }
