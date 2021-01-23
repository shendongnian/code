    interface IM
    {
       void m();
    }
    class Def {
        public void x(Abc abc) {
           if (abc is IM)
            ((IM) abc).m();
        }
    }
