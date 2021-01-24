    (from userAnswer in NIS_USER_ANSWERS
        where userAnswer.IsCorrectAnswer == true
        
        group userAnswer by new
        {
            SubCategoryName  = userAnswer.Question.SubCategory.Name ,
            userAnswer.Question.SubCategory.CategoryId,
            userAnswer.User.FirstName,
            userAnswer.User.LastName,
            userAnswer.User.MobileNumber,            
        }
        into g
        select new
        {
            g.Key.SubCategoryName,
            g.Key.CategoryId,
            g.Key.FirstName,
            g.Key.LastName,
            g.Key.MobileNumber,
            userMarks = g.Sum(a => a.Question.Marks)
        }
    )
  
