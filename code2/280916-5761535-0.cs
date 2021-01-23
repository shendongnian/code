         private static void RegexRemoveBracketedNumbers()
                {
                    string testIt = @"\[[0-9]{1,4}\]";
                    Console.WriteLine(testIt);
       // sure enough @Talljoe is right, this output as 
       //  \[[0-9]{1,4}\] without the @ it is an unrecognized escape sequence.. 
                    Regex regex = new Regex(@"\[[0-9]{1,4}\]", RegexOptions.Singleline);
                    string output = regex.Replace("[1] hello [2] world [a] how are you? [1234]", string.Empty);
                    Console.WriteLine(output);
        // output = "hello world [a] how are you?"
        // as expected.
                }
