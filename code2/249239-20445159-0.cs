    public static DateTime? ConvertToNallableDate(string date)
    		{
    
    			DateTime? val = null;
    			/*			/Date(1389435240000+0000)/*/
    			try{
    				if(!string.IsNullOrEmpty(date))
    				{
    					date = date.Replace ("/Date(", string.Empty).Replace (")/", string.Empty);
    					int pIndex = date.IndexOf ("+");
    					if(pIndex < 0) pIndex = date.IndexOf("-");
    					long millisec = 0;
    					date = date.Remove (pIndex);
    					long.TryParse (date, out millisec);
    					System.Globalization.CultureInfo ci = new System.Globalization.CultureInfo("en-GB");
    					DateTime newDate = DateTime.Parse ("1970,1,1", ci);
    					newDate = newDate.AddMilliseconds(millisec);
    					val = newDate == null ? (DateTime?)null : newDate;
    
    				}
    			}catch {
    				val = null;
    			}
    			return val;
    		}
    
    		public static DateTime ConvertToDate(string date)
    		{
    
    			DateTime val = new DateTime();
    			/*/Date(1389435240000+0000)/*/
    			try{
    			if(!string.IsNullOrEmpty(date))
    			{
    				date = date.Replace ("/Date(", string.Empty).Replace (")/", string.Empty);
    				int pIndex = date.IndexOf ("+");
    				if(pIndex < 0) pIndex = date.IndexOf("-");
    				long millisec = 0;
    				date = date.Remove (pIndex);
    				long.TryParse (date, out millisec);
    				System.Globalization.CultureInfo ci = new System.Globalization.CultureInfo("en-GB");
    				DateTime newDate = DateTime.Parse ("1970,1,1", ci);
    				val = newDate.AddMilliseconds(millisec);
    
    			}
    			}catch {
    				val = new DateTime();
    			}
    			return val;
    		}
