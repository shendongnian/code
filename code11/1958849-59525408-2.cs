    [TestClass]
    public class ProcessBuilderTests {
        [TestMethod]
        public async Task Should_Process_Steps_In_Sequence() {
            //Arrange
            var expected = 11;
            var builder = new ProcessBuilder<ProcessingArgs>()
                .Add(context => { context.Result = 10; return Task.CompletedTask; })
                .Add(context => { context.Result += 1; return Task.CompletedTask; });
            var process = builder.Build();
            var args = new ProcessingArgs();
            //Act
            await process.Invoke(args);
            //Assert
            args.Result.Should().Be(expected);
        }
        public class ProcessingArgs : EventArgs {
            public int Result { get; set; }
        }
    }
