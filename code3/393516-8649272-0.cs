    private SelectList GetStatusSelectList(int selectedStatusId)
    {
        return GetGenericSelectList<MemberStatus>(selectedStatusId, _memberStatusRepository.All().ToList(), "StatusId");
    }
    
    private SelectList GetTeamSelectList(int selectedTeamId)
    {
        return GetGenericSelectList<MemberTeam>(selectedTeamId, _memberTeamRepository.All().ToList(), "TeamId");
    }
    
    private SelectList GetGenericSelectList<T>(int selectedTeamId, List<T> list, string idFieldName) where T : new()
    {
        var firstItem = new T();
        (firstItem as dynamic).Name = "All";
        var l = new List<T>(list);
        l.Insert(0, firstItem);
        return new SelectList(l, idFieldName, "Name", selectedTeamId);
    }
