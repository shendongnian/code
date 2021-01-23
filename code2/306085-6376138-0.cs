    public Submission getSubmissionByID(int id)
    {
        SubmissionDatabaseService sds = new SubmissionDatabaseService();
        return sds.GetSubmissionsByID(id);
    }
