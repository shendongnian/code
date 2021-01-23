    interface I {
    	abstract void M();
    }
    
    class A : I {
    	virtual void M() {
    
    	}
    }
    
    class B : A {
    	override void M() {
    		//Do stuff;
			base.M();
    	}
    
    }
