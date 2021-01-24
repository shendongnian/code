    [TestClass]
    public class MyTestClass {
        [TestMethod]
        public async Task Should_Invoke_Callback() {
            //Arrange
            var someService = Substitute.For<ISomeService>();
            OneClass one = new OneClass();
            TwoClass two = new TwoClass();
            someService
                .UpdateAsync(Arg.Do<Action<OneClass, TwoClass>>(action => action(one, two)))
                .Returns(Task.CompletedTask);
            bool invoked = false;
            Action<OneClass, TwoClass> callback = (a, b) => {
                invoked = a != null && b != null;
            };
            //Act
            await someService.UpdateAsync(callback);
            //Assert - using FluentAssertions
            invoked.Should().BeTrue();
        }
    }
    public class TwoClass {
    }
    public class OneClass {
    }
    public interface ISomeService {
        Task UpdateAsync(Action<OneClass, TwoClass> action);
    }
