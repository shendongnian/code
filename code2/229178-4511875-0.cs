    // need to pull the Initial Set of Questions to start
    List<Question> currentQuestions = GetInitalQuestions();
    // a stack to track the chosen responses, so we can unwind if needed
    Stack<Response> responseStack = new Stack<Response>();
    // out exit condition is when currentQuestions is null
    while(currentQuestions != null)
    {
        // display the questions and get the user's response
        Response resp = DisplayQuestions(currentQuestions);
        // if we need to back up...
        if (resp == Response.Back)
        {
            // make sure we have something to fall back to...
            if (responseStack.Count > 0)
                resp = responseStack.Pop();
            else
                HandleAtBeginningOfStack();
        }
        else
        {
            // add the chosen response to the stack
            responseStack.Push(resp);
        }
        // get the next set of questions based on the response, unless we are at the end
        if (resp.IsFinal)
            currentQuestions = null;
        else
            currentQuestions = GetQuestionSetFromResponse(resp);
    }
