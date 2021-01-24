IQueryable<QuestionCategory> questionCategories = new EnumerableQuery<QuestionCategory>(Enumerable.Empty<QuestionCategory>());
var result = questionCategories.GroupBy(
    // key selector
    qc => new
    {
        categoryId = qc.CategoryId,
        categoryName = qc.Category.Name,
        IsRiquered = qc.IsRequired,
        Weigth = qc.Weigth
    },
    // element selector
    qc => qc.Question,
    // result selector
    (k, v) => new
    {
        k.categoryId,
        k.categoryName,
        k.IsRiquered,
        k.Weigth,
        questions = v.Select(q => new {questionId = q.Id, questionName = q.Name}).ToList()
    });
