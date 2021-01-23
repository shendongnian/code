    var actualDoubles = new double[] {1.0 / 3.0, 0.7, 9.981};
    var expectedDoubles = new double[] { 1.1 / 3.3, 0.7, 9.9810};
    Assert.That(actualDoubles, Is.EqualTo(expectedDoubles).Within(0.00001));
    Assert.That(actualDoubles, Is.EqualTo(expectedDoubles).Within(1).Ulps);
    Assert.That(actualDoubles, Is.EqualTo(expectedDoubles).Within(0.1).Percent);
