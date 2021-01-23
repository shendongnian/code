    interface IDummyParameters {
        int SomeInt {get;set;}
        int SomeOtherInt {get;set;}
    }
    public class Dummy {
        public Dummy(IDummyParameters parameters, IFoo foo){
            ...
        }
    }
