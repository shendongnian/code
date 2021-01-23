    class MyTextbox : Textbox {
        public bool MyEnable {
            get{ return someBool; }
            set {
                if (yourConditionIsMet) {
                    someBool = value;
                    this.Enabled = value;
                }
            }
        }
    }
