    public void uniqueSidesTest2()
    {
        try {
            Triangle_Accessor target = new Triangle_Accessor(0, 10, 10);
            Assert.Fail("An exception was not thrown for an invalid argument.");
        }
        catch (){
            //Do nothing, test passes if Assert.Fail() was not called
        }
    }
