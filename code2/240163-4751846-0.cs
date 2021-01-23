    public class GroupWrapper()
    {
       public GroupWrapper(GroupWith2Children group)
       {
          Group = group;
       }
       public GroupWith2Children Group { get; private set; ]
       public IEnumerable<GroupWithList> Groups
       {
          get
          {
             yield return Group.First;
             yield return Group.Second;
          }
       }
    }
