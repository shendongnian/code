    [TestClass]
    public class CollectionViewCommandsTests {
        [TestMethod]
        public void Should_Not_Move_Previous() {
            //Arrange
            var items = new[] { new object(), new object(), new object() };
            var view = new CollectionView(items);
            var expected = view.CurrentItem;
            ICommand command = new MoveCurrentToPreviousCommand(view);
            //Act
            command.Execute(null);
            //Assert
            var actual = view.CurrentItem;
            actual.Should().Be(expected);
        }
        [TestMethod]
        public void Should_Move_Next() {
            //Arrange
            var items = new[] { new object(), new object(), new object() };
            var view = new CollectionView(items);
            var expected = items[1];
            ICommand command = new MoveCurrentToNextCommand(view);
            //Act
            command.Execute(null);
            //Assert
            var actual = view.CurrentItem;
            actual.Should().Be(expected);
        }
        [TestMethod]
        public void Should_Not_Move_Next() {
            //Arrange
            var items = new[] { new object(), new object(), new object() };
            var view = new CollectionView(items);
            view.MoveCurrentToLast();
            var expected = view.CurrentItem;
            ICommand command = new MoveCurrentToNextCommand(view);
            //Act
            command.Execute(null);
            //Assert
            var actual = view.CurrentItem;
            actual.Should().Be(expected);
        }
        [TestMethod]
        public void Should_Move_Previous() {
            //Arrange
            var items = new[] { new object(), new object(), new object() };
            var view = new CollectionView(items);
            view.MoveCurrentToLast();
            var expected = items[1];
            ICommand command = new MoveCurrentToPreviousCommand(view);
            //Act
            command.Execute(null);
            //Assert
            var actual = view.CurrentItem;
            actual.Should().Be(expected);
        }
    }
