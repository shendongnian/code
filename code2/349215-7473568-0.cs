    public class Mechanism {
        public string Vin {get;set;}
    }
    
    public class Auto : Mechanism {
        public int NumberOfDoors {get;set;
    
        public override string ToString() {
            return string.Format("{0}, {1}", Vin, NumberOfDoors);
        }
    }
    
    public class Motorcycle : Mechanism {
        public string TypeOfMotorcycle {get;set; }
        
        public override string ToString() {
            return string.Format("{0}, {1}", Vin, TypeOfMotorcycle );
        }
    }
    
    foreach (Mechanism m in mechanisms) {
        Console.Print(m.ToString());
    }
