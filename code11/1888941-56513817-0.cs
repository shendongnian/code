    var actualValues = new List<bool> { };
    var objectUnderTheTest = new MyObject();
    objectUnderTheTest.PropertyChanged += (sender, args) =>
        { 
            var instance = (MyObject)sender;
            if (args.PropertyName == nameof(instance.CanExecute))
            {
                actualValues.Add(instance.BoolToTest);
            }
        }
     await objectUnderTheTest.Foo();
     var expected = new[] { true, false };
     actualValues.Should().BeEquivalentTo(expected, options => options.WithStrictOrdering());
