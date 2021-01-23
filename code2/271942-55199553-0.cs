    void BooleanTestV1 (){
        int num = 0;
        bool IsOne = false;
        for (int i = 0; i< 100; i++){
            num = i;
            if (IsOne == false) {
                IsOne = num == 1;
            }
        }
        if (IsOne) {
            // Yeay it works!
        }
    }
    void BooleanTestV2 (){
        int num = 0;
        bool IsOne = false;
        for (int i = 0; i< 100; i++){
            num = i;
            if (IsOne == false && (IsOne = num == 1)) {
                // Do Somehing...
            }
        }
        if (IsOne) {
            // Yeay it works!
        }
    }
    void WhyUseOneAND() {
        int num = 0;
        bool IsOne = false;
        for (int i = 0; i < 100; i++) {
            num = i;
            if (num < 0 & (IsOne == false && (IsOne = num == 1))) {
                // If we are using && 
                // isOne will never checking (num == 1)
                // Because && will stop running after found a false (num < 0)
                // Good for caching (here "IsOne" is the variable we cached)
                // Note: anything here will not be executed, cuz num < 0 will never be true
            }
        }
        if (IsOne) {
            // Yeay it works!
        }
    }
