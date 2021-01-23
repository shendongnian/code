    [Test]
    public void Can_Correctly_Map_Blah()
    {
        new PersistenceSpecification<Blah>(Session)
            .CheckProperty(c => c.Id, 1)
            .CheckProperty(c => c.Description, "Big Description")
            .CheckProperty(c => c.Created,  new DateTime(2016, 7, 15, 3, 15, 0) )
            .VerifyTheMappings();
    }
