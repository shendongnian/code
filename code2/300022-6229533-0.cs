    class C {
        int BadProperty {
            set {
                SomeMethod(value);
            }
        }
    
        void SomeMethod(int value) {
            // here is where you do really, really bad things
        }
    }
