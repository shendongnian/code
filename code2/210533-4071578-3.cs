    public class ItemViewModel
    {
        public IEnumerable<string> TestResults { get; set; }
        public string SummaryText { get; set; }
    }
    ...
    
    var viewModels = testResults.Select(tr => 
        new ItemViewModel() { 
          TestResults = testResults.Where(t => t.TestGroup == tr.TestGroup)
                                   .Select(t => t.TestName + " " + t.TestPassed),
          SummaryText = testSummaries.First(ts => ts.TestGroup == tr.TestGroup) 
        });
