   	//create the object. This object will store your phonetic 'characters'
	System.Speech.Synthesis.PromptBuilder PBuilder = new System.Speech.Synthesis.PromptBuilder();
	//add your phonetic 'characters' here. Just ignore the first parameter.
	//The second parameter is your phonetic 'characters'
	PBuilder.AppendTextWithPronunciation("test", "riːdɪŋ");
	//now create a speaker to speak your phonetic 'characters'
	System.Speech.Synthesis.SpeechSynthesizer SpeechSynthesizer2 = new System.Speech.Synthesis.SpeechSynthesizer();
	//now actually speaking. It will speak 'reading'
	SpeechSynthesizer2.Speak(PBuilder);
