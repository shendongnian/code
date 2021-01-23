    public class MyClass
    {
        clsPhone[] phoneArray;//set this however
        int tpc = 1;
        int opc = 2;
    
        clsPhone Tphone { get { return GetPhone(tpc); } }
        clsPhone Rphone { get { return GetPhone(opc); } }
    
        private clsPhone GetPhone(int phoneLoc)
        {
            return (clsPhone)phoneArray[phoneLoc];
        }
    
        public void MakeCall()
        {
            Tphone.ringPhone();
            Rphone.ringPhone();
        }
    }
