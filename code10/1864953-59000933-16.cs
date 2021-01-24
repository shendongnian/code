    [TestClass]
    public class CollectionViewCommandsTests {
        [TestMethod]
        public void Should_Not_Move_Previous() {
            //Arrange
            var items = new[] { new object(), new object(), new object() };
            var view = new CollectionView(items);
            var expected = view.CurrentItem;
            bool changed = false;
            ICommand command = new MoveCurrentToPreviousCommand(view);
            command.CanExecuteChanged += delegate {
                changed = true;
            };
            //Act
            command.Execute(null);
            //Assert
            var actual = view.CurrentItem;
            actual.Should().Be(expected);
            changed.Should().BeFalse();
        }
        [TestMethod]
        public void Should_Move_Next() {
            //Arrange
            var items = new[] { new object(), new object(), new object() };
            var view = new CollectionView(items);
            var expected = items[1];
            bool changed = false;
            ICommand command = new MoveCurrentToNextCommand(view);
            command.CanExecuteChanged += delegate {
                changed = true;
            };
            //Act
            command.Execute(null);
            //Assert
            var actual = view.CurrentItem;
            actual.Should().Be(expected);
            changed.Should().BeTrue();
        }
        [TestMethod]
        public void Should_Not_Move_Next() {
            //Arrange
            var items = new[] { new object(), new object(), new object() };
            var view = new CollectionView(items);
            view.MoveCurrentToLast();
            var expected = view.CurrentItem;
            bool changed = false;
            ICommand command = new MoveCurrentToNextCommand(view);
            command.CanExecuteChanged += delegate {
                changed = true;
            };
            //Act
            command.Execute(null);
            //Assert
            var actual = view.CurrentItem;
            actual.Should().Be(expected);
            changed.Should().BeFalse();
        }
        [TestMethod]
        public void Should_Move_Previous() {
            //Arrange
            var items = new[] { new object(), new object(), new object() };
            var view = new CollectionView(items);
            view.MoveCurrentToLast();
            var expected = items[1];
            bool changed = false;
            ICommand command = new MoveCurrentToPreviousCommand(view);
            command.CanExecuteChanged += delegate {
                changed = true;
            };
            //Act
            command.Execute(null);
            //Assert
            var actual = view.CurrentItem;
            actual.Should().Be(expected);
            changed.Should().BeTrue();
        }
    }
