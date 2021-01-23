    public class A {
        private static Object LOCK = new Object();
        private static void foo() {
            lock(LOCK) {
                // Do whatever
            }
        }
    }
