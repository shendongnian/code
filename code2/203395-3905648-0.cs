        //join the list into one and sort by seqnumber
      SegmentList = 
         Alist.Cast<BaseSegment>().Where(a => ATest(a))
         .Union(
            BList.Cast<BaseSegment>(.Where(b => BTest(b))
         .Union(CList.Cast<BaseSegment>().Where(c => CTest(c))
         .OrderBy(item => item.SegSeqNumber).ToList();
