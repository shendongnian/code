    [TestMethod]
    public void Can_Use_ISession()
    {
        ISession session = TestConfig.SessionFactory.GetCurrentSession();
        var ag = new AssetGroup { Name = "NHSession" };
        session.Save(ag);
        var a1 = new Asset { Name = "s1" };
        var a2 = new Asset { Name = "s2" };
        a1.SetAssetGroup(ag);
        a2.SetAssetGroup(ag);
        session.Flush();
        session.Refresh(ag);
        Assert.IsTrue(a1.Id != default(Guid)); // ok
        Assert.IsTrue(a2.Id != default(Guid)); // ok
        var enumerator = ag.Assets.GetEnumerator();
        enumerator.MoveNext();
        Assert.IsTrue(ag.Assets.Contains(enumerator.Current));  // failed
        Assert.IsTrue(ag.Assets.Contains(a1));  // failed
        Assert.IsTrue(ag.Assets.Contains(a2));  // failed 
        var agRepo2 = new NHibernateRepository<AssetGroup>(TestConfig.SessionFactory, new QueryFactory(TestConfig.Locator));
        Assert.IsTrue(agRepo2.Contains(ag)); // ok
        var ag2 = agRepo2.FirstOrDefault(x => x.Id == ag.Id);
        Assert.IsTrue(ag2.Assets.FirstOrDefault(x => x.Id == a1.Id) != null); // ok
        Assert.IsTrue(ag2.Assets.FirstOrDefault(x => x.Id == a2.Id) != null); // ok
        var aa1 = session.Get<Asset>(a1.Id);
        var aa2 = session.Get<Asset>(a2.Id);
        Assert.IsTrue(ag2.Assets.Contains(aa1));  // failed
        Assert.IsTrue(ag2.Assets.Contains(aa2));  // failed
    }
