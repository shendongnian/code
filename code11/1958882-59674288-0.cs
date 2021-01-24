    [HttpPost]
    public ActionResult AddOrEdit(Questions question)
    {
        if (question == null) // Assert and fail. Avoids nesting.
            return Json(new { success = true, message = "Bir problem oluştu." },
                JsonRequestBehavior.AllowGet);
        using (MerinosSurveyEntities db = new MerinosSurveyEntities())
        {
            Questions questionComing = db.Questions.Include(x => x.Options).SingleOrDefault(x => x.QuestionId == question.QuestionId); // Prefetch our options...
            if (questionComing != null)
            {   //Update
                questionComing.QuestionName = question.QuestionName;
                questionComing.Status = true;
                questionComing.IsActive = true;
                questionComing.UpdatedDate = DateTime.Now;
                // db.Questions.Attach(questionComing); -- not needed, already tracked
                // db.Entry(questionComing).State = EntityState.Modified; - Not needed
                // question.QuestionId = questionComing.QuestionId; -- Redundant. The ID matches, we loaded based on it.
                // db.SaveChanges(); -- No save yet.
                // Handle options here... There are probably optimizations that can be added.
                var activeOptionIds = question.Options.Where(x => x.Status && s.IsActive).Select(x => x.OptionId).ToList();
                foreach(var option in question.Options.Where(x => activeOptionIds.Contains(x.OptionId))
                {
                    var existingOption = questionComing.Options.SingleOrDefault(x => x.OptionId == option.OptionId);
                    if(existingOption != null)
                    { // Update
                        existingOption.UpdatedDate = DateTime.Now;
                        existingOption.OptionName = optionUpdated.OptionName;
                        existingOption.IsActive = true;
                        existingOption.Status = true;
                    }
                    else
                    { // New
                        questionComing.Options.Add(option); // Provided we trust the data coming in. Otherwise new up an option and copy over values.
                    }
                }
                var removedOptions = questionComing.Options.Where(x => !activeOptionIds.Contains(x.OptionId).ToList();
                foreach(var option in removedOptions)
                {
                    option.Status = option.IsActive = false;
                    option.UpdatedDate = DateTime.Now;
                } 
            }
            else
            {   //New Question
                // Dangerous to trust the Question coming in. Better to validate and copy values to a new Question to add...
                question.Status = true;
                question.IsActive = true;
                question.UpdatedDate = question.CreatedDate = DateTime.Now;
                
                // db.Questions.Attach(question); -- Add it...
                // db.Entry(question).State = EntityState.Added; 
                // question.QuestionId = question.QuestionId; -- Does nothing...
                db.Questions.Add(question); // This will append all Options as well.
            }
            
            // Now, after all changes are in, Save.
            db.SaveChanges();
            return Json(new { success = true, message = "Soru başarılı bir şekilde güncellendi." },JsonRequestBehavior.AllowGet);
        } // end using.
    }
