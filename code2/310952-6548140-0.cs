      SpeechRecognitionEngine rec = new SpeechRecognitionEngine();
      var c = new Choices();
      for (var i = 0; i <= 100; i++)
          c.Add(i.ToString());
      var gb = new GrammarBuilder(c);
      var g = new Grammar(gb);
      g.Priority = 127;
      rec.SetInputToDefaultAudioDevice();
      rec.LoadGrammar(g);
      rec.RecognizeAsync(RecognizeMode.Multiple);
