    double calc1DefaultingToCalc2(){
    	try { 
    		val = calc2(); 
    		if(specialValue(val)){
    			val = calc2DefaultingToCalc3WithConvertedException()
    		}
    	}
    	catch (Calc1Exception e1)
    	{
    		//defaulting to simpler method
    		return calc2defaultingToCalc3WithConvertedException();
    	}
    }
