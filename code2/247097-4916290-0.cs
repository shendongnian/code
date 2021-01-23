    class MyForm
    {
      SpeechSynthesizer synth = new SpeechSynthesizer(); 
      ...
    
      void On_Click(<params>)
      {
         this.synth.Speak(<text>);
      }
    
    }
