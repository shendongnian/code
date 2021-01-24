     public string status() {  
        if (isDriving == false) {
            return "The car is standing still";
        }
        else if (isDriving == true) {
            return "The car is moving";
        }
    }
