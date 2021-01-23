     private string _gender;
     public string Gender
     {
        get {
            string val = 
               (!string.IsNullOrEmpty(_gender) ? _gender : "[Not decided yet]");
            return val; 
        }
        set { _gender = value; }
     }
