    void ShuffleAnswersList()
    {             
        //  Notice this v--------------------v to avoid out of range exception
        for (int i = 0; i < positions.Count && i < answersButtons.Count; i++)
        {
    // always use i ------V---------------------------------V
           answersButtons[i].transform.position = positions[i];
        }
    }
