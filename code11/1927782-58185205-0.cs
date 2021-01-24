    static void  Main()
    {
        var output = "Hello, what is your Name?";
        await SynthesisToSpeakerAsync(output);
        var input = await RecognizeSpeechAsync();
        var output2 = ($"Hello {input}");
        await SynthesisToSpeakerAsync(output2);
        Console.WriteLine("Please press <Return> to continue.");
        Console.ReadLine();
    }
