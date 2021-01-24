    var results = // This section maps to the FROM part of SQL
                  from result in _db.EvaluationResults
                  join detail in _db.QuestionDetails
                    on result.QuestionDetailsId equals detail.Id
                  // This section maps to the WHERE part of SQL
                  where result.StudentId == 9
                  // Since variable scoping is difficult for grouping,
                  // you need to specify an intermediate select object
                  // before grouping. It needs to contain everything
                  // that is included in grouping or selection.
                  select new
                  {
                      result.StudentId,
                      result.Date,
                      detail.Value
                  } into intermediate
                  // This section maps to the GROUP BY part of SQL
                  group intermediate by new
                  {
                      intermediate.StudentId,
                      intermediate.Date
                  } into grouped
                  // This section maps to the SELECT part of SQL
                  select new
                  {
                      grouped.Key.StudentId,
                      grouped.Key.Date,
                      Summation = grouped.Sum(a => a.Value)
                  };
