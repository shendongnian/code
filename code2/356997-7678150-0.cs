    public static MyObject GetMyObject() {
            MyObject o = obj;
            if(o == null) {
                o = new MyObject();
                obj = o;
            }
            return o;
