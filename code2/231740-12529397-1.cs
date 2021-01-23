    string DecimalToBase(int iDec, int numbase)
    		{
    			string strBin = "";
    			int[] result = new int[32];
    			int MaxBit = 32;
    			for(; iDec > 0; iDec/=numbase)
    			{
    				int rem = iDec % numbase;
    					result[--MaxBit] = rem;
    			} 
    			for (int i=0;i<result.Length;i++)
    				if ((int)result.GetValue(i) >= base10)
    					strBin += cHexa[(int)result.GetValue(i)%base10];
    				else
    					strBin += result.GetValue(i);
    			strBin = strBin.TrimStart(new char[] {'0'});
    			return strBin;
    		}
    		int BaseToDecimal(string sBase, int numbase)
    		{
    			int dec = 0;
    			int b;
    			int iProduct=1;
    			string sHexa = "";
    			if (numbase > base10)
    				for (int i=0;i<cHexa.Length;i++)
    					sHexa += cHexa.GetValue(i).ToString();
    			for(int i=sBase.Length-1; i>=0; i--,iProduct *= numbase)
    			{
    				string sValue = sBase[i].ToString();
    				if (sValue.IndexOfAny(cHexa) >=0)
    					b=iHexaNumeric[sHexa.IndexOf(sBase[i])];
    				else 
    					b= (int) sBase[i] - asciiDiff;
    				dec += (b * iProduct);
    			} 
    			return dec; 
    		}
