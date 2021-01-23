    public static class AgentDescriptions
    {
      public static int P1 { get; private set; }
      public static int P2 { get; private set; }
      public static void Initialize(int AgencyId)
      {
          P1 = GetIDFromDB(AgencyId);
          P2 = GetIDFromDB(AgencyId);
      }
    }
