    static async Task Main() {
        try {
            await TaskEx.Run(() => { throw new Exception("failure"); });
        } catch(Exception) {
            throw new Exception("success");
        }
    }
    static async Task Main2() {
        await Main();
    }
    [Test]
    public void CallViaAwait() {
        var t = Main2();
        try {
            t.Wait();
            Assert.Fail("didn't throw");
        } catch(AggregateException e) {
            Assert.AreEqual("success",e.InnerException.Message);
        }
        }
    [Test]
    public void CallDirectly() {
        var t = Main();
        try {
            t.Wait();
            Assert.Fail("didn't throw");
        } catch(AggregateException e) {
            Assert.AreEqual("success", e.InnerException.Message);
        }
    }
