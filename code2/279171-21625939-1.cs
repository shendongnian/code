    [Fact]
    public void ShouldWorkWithSuperSortedSet()
    {
        // Sort points according to X
        var set = new SuperSortedSet<Point2D>
            (new System.Linq.Comparer<Point2D>((p0, p1) => p0.X.CompareTo(p1.X)));
        set.Add(new Point2D(9,10));
        set.Add(new Point2D(1,25));
        set.Add(new Point2D(11,-10));
        set.Add(new Point2D(2,99));
        set.Add(new Point2D(5,55));
        set.Add(new Point2D(5,23));
        set.Add(new Point2D(11,11));
        set.Add(new Point2D(21,12));
        set.Add(new Point2D(-1,76));
        set.Add(new Point2D(16,21));
        var xs = set.Select(p=>p.X).ToList();
        xs.Should().BeInAscendingOrder();
        xs.Count.Should()
           .Be(10);
        xs.ShouldBeEquivalentTo(new[]{-1,1,2,5,5,9,11,11,16,21});
        set.Remove(new Point2D(5,55));
        xs = set.Select(p=>p.X).ToList();
        xs.Count.Should()
           .Be(9);
        xs.ShouldBeEquivalentTo(new[]{-1,1,2,5,9,11,11,16,21});
        set.Remove(new Point2D(5,23));
        xs = set.Select(p=>p.X).ToList();
        xs.Count.Should()
           .Be(8);
        xs.ShouldBeEquivalentTo(new[]{-1,1,2,9,11,11,16,21});
        set.Contains(new Point2D(11, 11))
           .Should()
           .BeTrue();
        set.Contains(new Point2D(-1, 76))
            .Should().BeTrue();
        // Note that the custom compartor function ignores the Y value
        set.Contains(new Point2D(-1, 66))
            .Should().BeTrue();
        set.Contains(new Point2D(27, 66))
            .Should().BeFalse();
    }
