        [Test]
        public void Test()
        {
            var form1Mock = new Mock<IForm1>();
            var modelMock = new Mock<IModel>();
            var presenter = new Presenter(form1Mock.Object, modelMock.Object);
            modelMock.Setup(m => m.LongRunningTask()).Raises(m => m.Completed += null, new SampleEventArgs() { Data = "Some Data" });
            form1Mock.Raise(f => f.Button1Clicked += null, EventArgs.Empty);
            form1Mock.Verify(f => f.Update("Some Data"));
        } 
