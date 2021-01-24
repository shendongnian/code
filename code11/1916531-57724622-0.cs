    public static async Task<bool> QuestionResponse(int question)
    {
        while (questions[question] == Response.None)
            await Task.Delay(100);
    
        return questions[question] == Response.Yes;
    }
