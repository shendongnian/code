    public Submission getSubmissionByID(string id)
    {
        SubmissionDatabaseService sds = new SubmissionDatabaseService();
        return sds.GetSubmissionsByID(id);
    }
