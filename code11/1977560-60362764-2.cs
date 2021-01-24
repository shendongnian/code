    [TestMethod]
    public void Pose_Static_Shim_Demo_With_Out_Parameter() {
        //Arrange
        var path = Is.A<string>();
        var expectedResult = true;
        var expectedPath = "Hello World";
        var expectedId = "id";
        string actualId = null; ;
        StubForStaticImages stub = new StubForStaticImages((string a, out string b) => {
            b = expectedPath;
            actualId = a;
            return expectedResult;
        });
        Shim shim = Shim
            .Replace(() => FileOps.ImagesExistsInDirectory(Is.A<string>(), out path))
            .With(stub);
        //Act
        string actualPath = default(string);
        bool actualResult = default(bool);
        PoseContext.Isolate(() => {
            actualResult = FileOps.ImagesExistsInDirectory(expectedId, out actualPath);
        }, shim);
        //Assert - using FluentAssertions
        actualResult.Should().Be(expectedResult);   //true
        actualPath.Should().Be(expectedPath);       //Hello World
        actualId.Should().Be(expectedId);           //id
    }
