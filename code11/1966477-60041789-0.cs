    [TestClass]
    public class MyClassTests {
        [TestMethod]
        public void Should_Call_PropertyChanged_Once() {
            //Arrange            
            //Store calls
            IDictionary<string, int> properties = new Dictionary<string, int>();
            PropertyChangedEventHandler handler = new PropertyChangedEventHandler((s, e) => {
                if (!properties.ContainsKey(e.PropertyName))
                    properties.Add(e.PropertyName, 0);
                properties[e.PropertyName]++;
            });
            MyClass testObject = new MyClass();
            testObject.PropertyChanged += handler;
            string expectedPropertyName = nameof(MyClass.X);
            int expectedCount = 1;
            //Act
            testObject.X = testObject.X + 1;
            //Assert - using FluentAssertions
            properties.Should().ContainKey(expectedPropertyName);
            properties[expectedPropertyName].Should().Be(expectedCount);
        }
        class MyClass : INotifyPropertyChanged {
            public event PropertyChangedEventHandler PropertyChanged = delegate { };
            void raisePropertyChanged([CallerMemberName]string propertyName = null) {
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
            int x;
            public int X {
                get => x;
                set {
                    if (value != x) {
                        x = value;
                        raisePropertyChanged();
                    }
                }
            }
        }
    }
