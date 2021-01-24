    bool QuestionAnswered  = true;  // it is outside the button click or other functions
    
    void SomeMethod()
    {
        QuestionAnswered = false;
    }
    
    
    private void NextGasQuestion_Click(object sender, EventArgs e,bool QuestionAnswered,int GasQuestionsFailed)
    {
        if (QuestionAnswered  == false)
         {
            GasQuestionsFailed++;
         }
    } 
  
