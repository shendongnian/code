    class AClass {
        void CallIt() {
            Test();                     //not valid
            this.Test();                //valid 
        }
    }
    static class AnExtension {
        public static void Test(this AClass source) {
             
        }
    }
