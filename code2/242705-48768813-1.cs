    public int Hour {
        get{
            // Do some logic if you want
            //return some custom stuff based on logic
            // or just return the value
            return value;
        }; set { 
            // Do some logic stuff 
            if(value < MINVALUE){
                this.Hour = 0;
            } else {
                // Or just set the value
                this.Hour = value;
            }
        }
    }
