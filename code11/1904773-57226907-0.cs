    (from userAnswer in NIS_USER_ANSWERS
        where userAnswer.IsCorrectAnswer == true
        join nisUser     in NIS_USERS          on userAnswer.UserId       equals nisUser.ID                                                                   
        join question    in NIS_QUESTIONS      on userAnswer.QuestionId   equals question.ID   
        join subCategory in NIS_SUBCATEGORies  on question.SubcategoryId  equals subCategory.ID 
        group new { userAnswer, question } by new
        {
            SubCategoryName  = subCategory.Name,
            subCategory.CategoryId,
            nisUser.FirstName,
            nisUser.LastName,
            nisUser.MobileNumber,            
        }
        into g
        select new
        {
            g.Key.SubCategoryName,
            g.Key.CategoryId,
            g.Key.FirstName,
            g.Key.LastName,
            g.Key.MobileNumber,
            userMarks = g.Sum(a => a.question.Marks)
        }
    )
