    private void MethodOne() 
    { 
 
        bool isValid = false; 
 
        // first layer 
        isValid  = ValidationRuleOne();
        if (!isValid) { goto tagApplyValidationResult; }
        isValid  = ValidationRuleTwo();
        if (!isValid) { goto tagApplyValidationResult; }
        isValid  = ValidationRuleThree()
     tagApplyValidationResult:
        if (!isValid) { Whine(); }
        else          { DoTheHappyDance(); }
    } 
