    var intersectionDetail1 = path1.Data.FillContainsWithDetail(path2.Data);
    var intersectionDetail2 = path1.Data.FillContainsWithDetail(path3.Data);
        
    if (intersectionDetail1 != IntersectionDetail1.NotCalculated &&
        intersectionDetail1 != IntersectionDetail1.Empty)
    {
        // collision with path part 1
    }
    if (intersectionDetail2 != IntersectionDetail2.NotCalculated &&
        intersectionDetail2 != IntersectionDetail2.Empty)
    {
        // collision with path part 2
    }
