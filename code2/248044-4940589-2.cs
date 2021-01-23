    public delegate bool HasHandler(INamed named);
    // delete method matching HasHandler declaration
    bool MyHandler(INamed named) {
    	return true;
    }
    
    // method that passes your implemented delegate method as a parameter
    void MyOtherMethod() {
    	MyMethod(null, (n) => MyHandler(n)); // using lambda
        MyMethod(null, MyHandler); // not using lambda
    }
    
    // method that uses your implemented delegate method
    // this would be like your CheckboxList method
    void MyMethod(INamed o, HasHandler handler) {
    	handler(o);
    }
