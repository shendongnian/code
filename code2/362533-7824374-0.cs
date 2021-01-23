    protected List<MoodleCourse> GetMoodleCourses()
    {
        List<MoodleCourse> list = (List<MoodleCourse>)ViewState["MoodleCoursesCreated"];
        if (list == null)
        {
            list = new List<MoodleCourse>();
            ViewState["MoodleCoursesCreated"] = list;
        }
        return list;
    }
