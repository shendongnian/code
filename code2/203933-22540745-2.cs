    public string GetCntnrLvlDscptn(TrayLevelCodes enumCode)
    		{
    			string sCode = "";
    			switch (enumCode)
    			{
    				case TrayLevelCodes._5DGS:
    					sCode = "\"5DGS\"";
    					break;
    				case TrayLevelCodes._5DG:
    					sCode = "\"5DG\"";
    					break;
    				case TrayLevelCodes._3DGS:
    					sCode = "\"3DGS\"";
    					break;
    				case TrayLevelCodes._3DG:
    					sCode = "\"3DG\"";
    					break;
    				case TrayLevelCodes._AADC:
    					sCode = "\"AADC\"";
    					break;
    				case TrayLevelCodes._ADC:
    					sCode = "\"AAC\"";
    					break;
    				case TrayLevelCodes._MAAD:
    					sCode = "\"MAAD\"";
    					break;
    				case TrayLevelCodes._MADC:
    					sCode = "\"MADC\"";
    					break;
    				default:
    					sCode = "";
    					break;
    			}
    				return sCode;
    		}
