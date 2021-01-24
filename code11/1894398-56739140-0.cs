        public class Parent {
            public int var1 = 1;
        }
        public class Child : Parent {
            public int var2 = 2;
        }
        public void foo () {
            Parent theObject = new Child();
            int num1 = theObject.var1;          // Valid
            int num2 = theObject.var2;          // Invalid
            int num3 = ((Child)theObject).var2; // Valid
        }
