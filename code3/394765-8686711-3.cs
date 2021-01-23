    public ResultValue Result
    {
        get
        {
            if (m_UserAns == m_CorrectAnswer)
            {
                return ResultValue.Correct;
            }
            else
            {
                return ResultValue.Incorrect;
            }
        }
    }
