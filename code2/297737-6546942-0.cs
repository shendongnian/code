    public void MyUiMethod(bool p)
    {
        UIMap MapName = new UIMap();
        //...variable initialization...
        ApplicationUnderTest app = ApplicationUnderTest.Launch(@"some.exe");
        try
        {
            //... get to the point that triggers the MB to show...
            Assert.AreEqual(true, MapName.uImessageBoxWindow.Exists);
        
            UIMap MapName = new UIMap();
            if (p)
                Mouse.Click(MapName.uIConfirmButton, new Point(39, 16));
            else
                Mouse.Click(MapName.uICancelButton, new Point(49, 8));
        }
        finally
        {
            app.Close();
        }
    }
