    private class MySecondObject {
    
    	private MyObject myObject;
    
        public string PropertyOneCopy {
    		get{
    			return myObject.PropertyOne;
    		}
    	}
    
        public MySecondObject(MyObject myObject)     {
            myObject = myObject.PropertyOne;
            ....
        }
    }
