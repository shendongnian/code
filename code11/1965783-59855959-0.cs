IQueryable<Study> studiesCoreModelsQuery = this._dbContext.Studies;
var expression = Study.ShouldNameBeDisplayedForStaffExpression(staffId);
IQueryable<StudyViewModel> query = studiesCoreModelsQuery.AsExpandable().Select(x => new StudyViewModel
{
    Name = expression.Invoke(x)
        ? x.Name
        : "Hidden"
});
