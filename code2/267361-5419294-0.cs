    private void btnTest_Click(object sender, EventArgs e)
    {
        SpeechRecognitionEngine myRecognizer = new SpeechRecognitionEngine();
    
        Grammar testGrammar = CreateTestGrammar();  
        myRecognizer.LoadGrammar(testGrammar);
    
        // use microphone
        try
        {
            myRecognizer.SetInputToDefaultAudioDevice();
            WriteTextOuput("");
            RecognitionResult result = myRecognizer.Recognize();              
            
            string item = null;
            float confidence = 0.0F;
            if (result.Semantics.ContainsKey("item"))
            {
                item = result.Semantics["item"].Value.ToString();
                confidence = result.Semantics["item"].Confidence;
                WriteTextOuput(String.Format("Item is '{0}' with confidence {1}.", item, confidence));
            }
        }
        catch (InvalidOperationException exception)
        {
            WriteTextOuput(String.Format("Could not recognize input from default aduio device. Is a microphone or sound card available?\r\n{0} - {1}.", exception.Source, exception.Message));
            myRecognizer.UnloadAllGrammars();
        }
    
    }
    
    private Grammar CreateTestGrammar()
    {                        
        // item
        Choices item = new Choices();
        SemanticResultValue itemSRV;
        itemSRV = new SemanticResultValue("I E", "explorer");
        item.Add(itemSRV);
        itemSRV = new SemanticResultValue("explorer", "explorer");
        item.Add(itemSRV);
        itemSRV = new SemanticResultValue("firefox", "firefox");
        item.Add(itemSRV);
        itemSRV = new SemanticResultValue("mozilla", "firefox");
        item.Add(itemSRV);
        itemSRV = new SemanticResultValue("chrome", "chrome");
        item.Add(itemSRV);
        itemSRV = new SemanticResultValue("google chrome", "chrome");
        item.Add(itemSRV);
        SemanticResultKey itemSemKey = new SemanticResultKey("item", item);
    
        //build the permutations of choices...
        GrammarBuilder gb = new GrammarBuilder();
        gb.Append(itemSemKey);
    
        //now build the complete pattern...
        GrammarBuilder itemRequest = new GrammarBuilder();
        //pre-amble "[I'd like] a"
        itemRequest.Append(new Choices("Can you open", "Open", "Please open"));
        
        itemRequest.Append(gb, 0, 1);
    
        Grammar TestGrammar = new Grammar(itemRequest);
        return TestGrammar;
    }
