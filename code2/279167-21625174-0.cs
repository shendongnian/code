    [Fact]
    public void ShouldBeAbleToUseCustomComparatorWithSortedSet()
    {
        // Create comparer that compares on X value but when X
        // X values are uses the index
        var comparer = new 
            System.Linq.Comparer<Indexed<Point2D>>(( p0, p1 ) =>
            {
                var r = p0.Value.X.CompareTo(p1.Value.X);
                return r == 0 ? p0.Index.CompareTo(p1.Index) : r;
            });
        // Sort points according to X
        var set = new SortedSet<Indexed<Point2D>>(comparer);
        int i=0;
        // Create a helper function to wrap each point in a unique index
        Action<Point2D> index = p =>
        {
            var ip = Indexed.Create(i++, p);
            set.Add(ip);
        };
        index(new Point2D(9,10));
        index(new Point2D(1,25));
        index(new Point2D(11,-10));
        index(new Point2D(2,99));
        index(new Point2D(5,55));
        index(new Point2D(5,23));
        index(new Point2D(11,11));
        index(new Point2D(21,12));
        index(new Point2D(-1,76));
        index(new Point2D(16,21));
        set.Count.Should()
           .Be(10);
        var xs = set.Select(p=>p.Value.X).ToList();
        xs.Should()
          .BeInAscendingOrder();
        xs.ShouldBeEquivalentTo(new[]{-1,1,2,5,5,9,11,11,16,21});
    }
