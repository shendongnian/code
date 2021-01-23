    public void Main() {
        dynamic dynamicObject = 33;
        if(true) { // Arbitrary logic
            dynamicObject = null;
        }
        Method(dynamicObject);
    }
    public void Method(int param) {
      //don't have to check check null
      //only called if dynamicObject is an int
    }
    public void Method(object param) {
    // will be called if dynamicObject is not an int or null
    }
