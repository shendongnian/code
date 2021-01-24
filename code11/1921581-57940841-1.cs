    public static class CommonMethods
    {
        public static int AgendaFileCount(int AgendaID)
        {
            // Some function using linq you want to do
            ApplicationDbContext db = new ApplicationDbContext();
            return db.MeetingAgendaDocument.Where(c => c.MeetingAgendaID == AgendaID).Count();
        }
    }
