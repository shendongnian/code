csharp
[TestClass]
public class LighthouseTest
{
    [TestMethod]
    public void ExampleComAudit()
    {
        var lh = new Lighthouse();
        var res = lh.Run("http://example.com").Result;
        Assert.IsNotNull(res);
        Assert.IsNotNull(res.Performance);
        Assert.IsTrue(res.Performance > 0.5m);
        Assert.IsNotNull(res.Accessibility);
        Assert.IsTrue(res.Accessibility > 0.5m);
        Assert.IsNotNull(res.BestPractices);
        Assert.IsTrue(res.BestPractices > 0.5m);
        Assert.IsNotNull(res.Pwa);
        Assert.IsTrue(res.Pwa > 0.5m);
        Assert.IsNotNull(res.Seo);
        Assert.IsTrue(res.Seo > 0.5m);
    }
}
