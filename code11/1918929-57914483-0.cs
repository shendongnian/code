      private ButtoncallbackHandler buttoncallback;
      void Start ()
      {
      buttoncallback= GameObject.FindObjectOfType<ButtoncallbackHandler >();
      if(buttoncallback)
       {
        buttoncallback.ScoreButton.onClick.AddListener(() => AnswerValidity());
        buttoncallback.ResteBTN.onClick.AddListener(() => RestButton());
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
