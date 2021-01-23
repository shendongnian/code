    [Test]
    public void Date_Can_Be_Pulled_Via_Provided_Month_Day_Year()
    {
        // Arrange
        var formCollection = new NameValueCollection { 
            { "foo.month", "2" },
            { "foo.day", "12" },
            { "foo.year", "1964" }
        };
    
        var valueProvider = new NameValueCollectionValueProvider(formCollection, null);
        var modelMetadata = ModelMetadataProviders.Current.GetMetadataForType(null, typeof(FwpUser));
    
        var bindingContext = new ModelBindingContext
        {
            ModelName = "foo",
            ValueProvider = valueProvider,
            ModelMetadata = modelMetadata
        };
    
        DateAndTimeModelBinder b = new DateAndTimeModelBinder { Month = "month", Day = "day", Year = "year" };
        ControllerContext controllerContext = new ControllerContext();
    
        // Act
        DateTime result = (DateTime)b.BindModel(controllerContext, bindingContext);
    
        // Assert
        Assert.AreEqual(DateTime.Parse("1964-02-12 12:00:00 am"), result);
    }
