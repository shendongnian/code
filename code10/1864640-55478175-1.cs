var question = await _dbContext.Questions
                                .Include(x => x.SurveySection)
                                .Include(x => x.Survey)
                                .Where(x => x.SurveyId == surveyId)
                                .OrderBy(x => x.Position)
                                                  .ToListAsync();
var responses = await _dbContext.Responses
                                .Where(x => x.SiteUserId == siteUserId &&
                                            x.SurveyPeriodId == surveyPeriodId)
                                .ToListAsync();
var responseIssues = await _dbContext.ResponseIssues
                                .Where(x => x.SurveyPeriodId == surveyPeriodId &&
                                            x.SiteUserId == siteUserId)
                                .ToListAsync();
foreach (var item in question)
{
    var foundResponse = responses.Where(x => x.QuestionId == item.Id).ToList();
    var foundResponseIssue = responseIssues.Where(x => x.QuestionId == item.Id).ToList();
    if (foundResponse != null)
    {
        item.Responses = foundResponse;
    }
    if (foundResponseIssue != null)
    {
        item.ResponseIssues = foundResponseIssue;
    }
}
