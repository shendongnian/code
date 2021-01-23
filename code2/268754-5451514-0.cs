    public static IList<ActionHistoryData> GetActionHistoryList(DateTime startDate, DateTime endDate, bool postprocessed)
    {
       return GlobalComponents.DataManagerImpl.GetActionHistoryList(null, null, null, null, null, null, null, startDate, endDate, false, postprocessed, null);
    }
    public static ActionHistoryData GetActionHistory(int id)
    {
        IList<ActionHistoryData> actionHistoryList =
            GlobalComponents.DataManagerImpl.GetActionHistoryList(id, null, null, null, null, null, null, null, null, null, null, null);
        CQGUtils.Verify(!CollectionsUtil.IsEmpty(actionHistoryList), "There is no action history with [ID='{0}']", id);
        CQGUtils.Verify(actionHistoryList.Count == 1, "More than one action history returned.");
        return actionHistoryList[0];
    }
