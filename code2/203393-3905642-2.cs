    SegmentList = Alist.Cast<BaseSegment>()
                       .Union(includeB ? BList.Cast<BaseSegment>() : Enumerable.Empty<BaseSegment>())
                       .Union(includeC ? CList.Cast<BaseSegment>() : Enumerable.Empty<BaseSegment>())
                       .OrderBy(item => item.SegSeqNumber)
                       .ToList();
