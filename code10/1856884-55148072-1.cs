     switch(checkboxvalue)
        {
        case (("ABCD")): //<---Contains "ACD" but not "B" NO MATCH
        SQL;
        break;
    
        case (("ABC")): //<---- Contains "A" but not "BC" NO MATCH
        SQL;
        break;
    
        case (("AB")): //<--Contains "A" but no "B" NO MATCH
        SQL;
        break; 
        case (("AC")): //<--Contains "AC" but no "D" NO MATCH
        SQL;
        break;
        case (("ACD")): //<--MATCH! 
        SQL Statement; //<--add to select to pull correct information
        break;
        }
