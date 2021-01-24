private async Task<List<PicklistValue>> GetSubject()
 {
    var allEvents = await _api.GetAllEvents();
    var subjectList = allEvents.Fields.Where(x => x.Name == "Subject").Select(x => 
           x.PicklistValues).FirstOrDefault().ToList();
    return subjectList;
 }
