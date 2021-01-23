    using (ShimsContext.Create())
    {
        System.Fakes.ShimDateTime.NowGet = () => new DateTime(1837, 1, 1);
        Assert.AreEqual(DateTime.Now.Year, 1837);
    }
