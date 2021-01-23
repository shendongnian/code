    [TestMethod]
    public void ByteArrayReleasesMemoryWhenTheyGoOutOfScope()
    {
        // *** WORKS ONLY IN RELEASE MODE ***
        // arrange
        var weakRef = new WeakReference(null);
        // easy way to generate byte array
        var byteArray = Guid.NewGuid().ToByteArray();
        weakRef.Target = byteArray;
        // act
        GC.Collect();
        GC.WaitForPendingFinalizers();
        GC.Collect();
        // assert
        Assert.IsFalse(weakRef.IsAlive);
    }
