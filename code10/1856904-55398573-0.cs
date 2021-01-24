    /// <summary>
    /// Map list of SubquestionVM (SubquestionCurrentMapping) with data from current Component (EF model).
    /// 
    /// Why are we doing this?
    ///		Because when using the ExpressMapping to map 'SubQuestion' to 'SubQuestionVM', it creates a stack overflow error on the property 'SubquestionCurrentMapping'
    ///		which is caused by recursive VM.
    ///		I originaly tried alternative solution like:
    ///			changing 'List<SubQuestionVM>' for 'List<SubQuestionMappedVM>' but the website was not even loading (even with proper value in the new VM, and global.asax),
    ///			loading the faulty property later on, but any attempt to populate the object was resulting in an overflow at a moment or another.
    ///		Thankfully the manual mapping is proven to be effective and errorless!
    /// </summary>
    /// <param name="evaluationVM"></param>
    /// <param name="component"></param>
    private static void ManualMappingOfRecursiveSubquestionVM(CurrentEvaluationVM evaluationVM, Component component)
    {
    	foreach (var subquestion in component?.Question?.SubQuestions)
    	{
    		//Find corresponding subquestionVM and manually map them
    		var subquestionVM = evaluationVM.CurrentComponent?.Question?.SubQuestions.Find(s => s.ID == subquestion.ID);
    
    		foreach (var subquestionMapping in subquestion.SubquestionCurrentMapping.ToList())
    		{
    			var tempSubquestionVM = new SubQuestionVM
    			{
    				ID = subquestionMapping.ID,
    				QuestionID = subquestionMapping.QuestionID,
    				Name = subquestionMapping.Name,
    				Clarification = subquestionMapping.Clarification,
    				Description = subquestionMapping.Description,
    				Index = subquestionMapping.Index,
    				CanSelectGoal = subquestionMapping.CanSelectGoal,
    				IsDate = subquestionMapping.IsDate,
    				Deprecated = subquestionMapping.Deprecated,
    				MultipleChoices = subquestionMapping.MultipleChoices.Map<ICollection<MultipleChoice>, List<MultipleChoiceVM>>(),
    				Answers = subquestionMapping.Answers.Map<ICollection<Answer>, List<AnswerVM>>()
    			};
    			subquestionVM.SubquestionCurrentMapping.Add(tempSubquestionVM);
    		}
    	}
    }
