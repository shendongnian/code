    [TestMethod, Asynchronous]
    public void testNullInsert()
    {
        wipeTestData((string errorString) =>
        {
            IdentityProperties properties = new IdentityProperties(getContext());
            properties.setUserName(DATABASE_TEST);
            postUserEdit(properties, testNullInsertContinue2);
        });
    }
