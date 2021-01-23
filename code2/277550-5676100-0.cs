    public static int TicketsRequiringSupportResponse()
    {
        using (var dc = new CrystalCommon.MainContext())
        {
            return dc.tblHelpCentreQuestions.Where(
                c => c.awaitingSupportResponse == true).Count();
        }
    }
