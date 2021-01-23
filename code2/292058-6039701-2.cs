    using (var speechSynthesizer = new SpeechSynthesizer())
    {
        while (true)
        {
            var consoleKey = Console.ReadKey();
            if (consoleKey.Key == ConsoleKey.Escape)
                break;
            var text = consoleKey.KeyChar.ToString();
            speechSynthesizer.Speak(text);
        }
    }
