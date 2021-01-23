    struct PersonName {
    
        public string Forename { get; set; }
        public string Surname { get; set; }
        public PersonName(string fn, string sn) {
            Forename = fn;
            Surname = sn;
        }
    
    }
    
    class MyPerson {
    
        public string Forename { get; set; }
        public string Surname { get; set; }
        public DateTime dob { get; set; }
    
        ...
        
        public PersonName Fullname {
            get { return Forename + " " + Surname; }
            set {
                Forename = value.Forename;
                Surname = value.Surname;
            }
        }
    }
    ...
    
        public void main() {
            MyPerson aPerson = new MyPerson;
            aPerson.Fullname = new PersonName("Fred", "Bloggs");
        }
