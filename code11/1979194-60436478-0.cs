csharp
[Fact]
public void SimpleMovingAverage_MultipleCloseValues_ReturnsSMA()
{
    // Arrange
    SimpleMovingAverage sma = new SimpleMovingAverage(5);
    List<decimal> values = new List<decimal>
    {
        0.01668m,
        0.01666m
    };
    sma.Add(0.01692m);
    sma.Add(0.01685m);
    sma.Add(0.01686m);
    sma.AddRange(values);
    // Act
    decimal actual = sma.GetResult();
    // Assert
    Assert.Equal(0.016794m, actual);
}
