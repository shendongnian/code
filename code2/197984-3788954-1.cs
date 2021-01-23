    private class MembershipComparer : IComparer<Membership>
    {
      public int Compare(Membership x, Membership y)
      {
        return x.StartDate.CompareTo(y.StartDate);
      }
    }
    private static bool AddMembership(List<Membership> lst, Membership ms)
    {
      int bsr = lst.BinarySearch(ms, new MembershipComparer());
      if(bsr >= 0)    //existing object has precisely the same StartDate and hence overlaps
                      //(you may or may not want to consider the case of a zero-second date range)
        return false;
      int idx = ~bsr; //index to insert at if doesn't match already.
      if(idx != 0)
      {
        Membership prev = lst[idx - 1];
        // if inclusive ranges is allowed (previous end precisely the same
        // as next start, change this line to:
        // if(!prev.EndDate.HasValue || prev.EndDate > ms.StartDate)
        if(prev.EndDate ?? DateTime.MaxValue >= ms.StartDate)
          return false;
      }
      if(idx != lst.Count)
      {
        Membership next = lst[idx];
        // if inclusive range is allowed, change to:
        // if(!ms.EndDate.HasValue || ms.EndDate > next.StartDate)
        if(ms.EndDate ?? DateTime.MaxValue >= next.StartDate)
          return false;
      }
      lst.Insert(idx, ms);
      return true;
    }
