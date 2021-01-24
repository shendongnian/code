    [Theory]
    [MemberData(nameof(PeriodData))]
    public void ShouldParsePeriod(string periodString, int value, PeriodUnit periodUnit) {
        var period = Period.Parse(periodString);
        period.Value.Should().Be(value);
        period.PeriodUnit.Should().Be(periodUnit);
    }
    public static IEnumerable<object[]> PeriodData() {
        yield return new object[] { "12h", 12, PeriodUnit.Hour };
        yield return new object[] { "3d", 3, PeriodUnit.Day };
        yield return new object[] { "1m", 1, PeriodUnit.Month };
    }
