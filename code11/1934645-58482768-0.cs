    public void TestFunc(){
    	// declare all variables here
    	ResultType res1, res2, res3, res4, res5;
        try{
            res1 = Procedure1();
            res2 = Procedure2(res1);
            res3 = Procedure3(res2);
        }
        catch{
            // if error in step 1-3 throw exception 1
        }
        try{
            res4 = Procedure4(res3); // error, res3 cannot be found in the context
            res5 = Procedure5(res4);
            Procedure6(res5);
        }
        catch{
            // if error in step 4-6 throw exception 2
        }
    }
