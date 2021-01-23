    void M()
    {
        try {
            b bee=new b();
            bee.read(name);
            bee.write(name);// don want this to get executed if exception is thrown
        }
        catch(Exception e) {
            // Proper error handling
        }
    }
