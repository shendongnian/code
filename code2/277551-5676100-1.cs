    public static int TicketsRequiringSupportResponse()
    {
        using (var dataContext = new CrystalCommon.MainContext())
        {
            return dataContext .tblHelpCentreQuestions.Where(
                question => question.awaitingSupportResponse == true).Count();
        }
    }
