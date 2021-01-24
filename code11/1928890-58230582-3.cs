    public static boolean IsDispayed(WebElement webelement)
    {
    	try {
    		webelement.isDisplayed();
    	} catch (Exception e) {
    		return false;
    	}
    	return webelement.isDisplayed();
    }
