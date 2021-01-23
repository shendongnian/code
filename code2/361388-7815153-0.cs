    double calc3WithConvertedException(){
    	try { val = calc3(); }
    	catch (Calc3Exception e3)
    	{
    		throw new NoCalcsWorkedException();
    	}
    }
    
    double calc2DefaultingToCalc3WithConvertedException(){
    	try { val = calc2(); }
    	catch (Calc2Exception e2)
    	{
    		//defaulting to simpler method
    		return calc3WithConvertedException();
    	}
    }
    
    
    double calc1DefaultingToCalc2(){
    	try { val = calc2(); }
    	catch (Calc1Exception e1)
    	{
    		//defaulting to simpler method
    		return calc2defaultingToCalc3WithConvertedException();
    	}
    }
