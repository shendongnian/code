     class Parent
     {
           private void AVeryPrivilegedMethod() {}
           public static void AVeryPrivilegedMethod(Child2 c) { ((Parent)c).AVeryPrivilegedMethod(); }
           public static void AVeryPrivilegedMethod(Child3 c) { ((Parent)c).AVeryPrivilegedMethod(); }
     }
           
