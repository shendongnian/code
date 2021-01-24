    public async Task CheckAvailability()
    {
        bool showFirstMessage = false;
        switch (Settings.Mode)
        {
            case Enums.MO.Learn:
                showFirstMessage = await IsLearn();
                break;
            case Enums.MO.Practice:
                showFirstMessage = await IsPractice();
                break;
            case Enums.MO.Quiz:
                showFirstMessage = await IsQuiz();
                break;
            default:
                break;
        }
        if (showFirstMessage)
        {
            await ShowFirstMessageAsync();
            return;
        }
        await PickCard();
    }
