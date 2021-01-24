    [TestCaseSource(nameof(ProvideTestCases1))]
    public void SubtractSegmentsTests(IPolyline polyline, IPolyline toRemove, double tol, IGeometry expected)
    {
        GeometryTools.SubtractSegments(polyline, toRemove, tol, null);
        AssertEqualPoints((IPointCollection) expected, (IPointCollection) polyline);
    }
    [TestCaseSource(nameof(ProvideTestCases2))]
    public void SubtractSegmentsTests_With_Esri(IPolyline polyline, IPolyline toRemove, double tol, IGeometry expected)
    {
        var actual = ((ITopologicalOperator)polyline).Difference(toRemove);
        AssertEqualPoints((IPointCollection)expected, (IPointCollection)actual);
    }
