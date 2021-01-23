    public string Result
    {
        get
        {
            if (m_UserAns == m_CorrectAnswer)
            {
                return "Correct";
            }
            else
            {
                return "Incorrect";
            }
        }
    }
