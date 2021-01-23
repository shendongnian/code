    public class DerivedClass : BaseClass{
    
        public string Name { get; set; }
    
        public override void Write(DerivedClass data) {
            Console.printLn(data.Name);
            base.Write(data)
        }
        // why print a different instance, just write self
        public void Write() {
            Console.printLn(this.Name);
            base.Write(this)
        }
    
    }
