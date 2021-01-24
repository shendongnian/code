       try {
            var res1 = Procedure1();
            var res2 = Procedure2(res1);
            var res3 = Procedure3(res2);
    
            try { 
                var res4 = Procedure4(res3);
                var res5 = Procedure5(res4);
    
                Procedure6(res5); 
            }
            catch {
                // Specific exceptions if error/exception occurs in step 4-6 
            }   
        }
        catch {
            // Exceptions within res1...res3
            // Unspecific Exceptions within steps 4-6
        }
