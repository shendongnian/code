    [TestClass]
    public class ProcessBuilderTests {
        [TestMethod]
        public async Task Should_Process_Steps_In_Sequence() {
            //Arrange
            var expected = 11;
            var builder = new ProcessBuilder()
                .AddStep(context => context.Result = 10)
                .AddStep(async (context, next) => {
                    //do something before
                    //pass context down stream
                    await next(context);
                    //do something after;
                })
                .AddStep(context => { context.Result += 1; return Task.CompletedTask; });
            var process = builder.Build();
            var args = new ProcessingArgs();
            //Act
            await process.Invoke(args);
            //Assert
            args.Result.Should().Be(expected);
        }
        public class ProcessBuilder : PipelineBuilder<ProcessingArgs> {
        }
        public class ProcessingArgs : EventArgs {
            public int Result { get; set; }
        }
    }
