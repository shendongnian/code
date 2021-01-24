     private ButtoncallbackHandler buttoncallback;
     void Start ()
     {
      buttoncallback= GameObject.FindObjectOfType<ButtoncallbackHandler >();
      if(buttoncallback)
     {
        buttoncallback.ScoreButton.onClick.AddListener(() => AnswerValidity());
        buttoncallback.ResetButton.onClick.AddListener(() => OnResetClick());
     }
     }
    
     void AnswerValidity()
     {
      if(answerisCorrect)
      {
     
       GameInstance1.Score++;
 
      }
      else
      {
      ///Wrong Answer Logic.
      }
     
       // Update your Text Box here
       UpdateTextBox();
     }
     void OnResetClick()
     {
      // Do what you want to do in reset
      UpdateTextBox();
     }
