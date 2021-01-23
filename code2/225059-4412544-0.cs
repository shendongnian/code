    class bird {
        protected virtual string Fly {
            get {
                return "Yes, I can!";
            }
        }
        public string CanI() { return Fly; }
    }
    
    class penguin : bird {
        protected override string Fly {
            get {
                return "No, I can't!"; 
            }
        }
    }
