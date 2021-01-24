`
            string input = @"INSERT [dbo].[Table] ([Key], [Name], [Value], [Module]) VALUES (1, N'Product', N'Value 1', N'Value 2')";
            Regex regex = new Regex("N'([^']+)'");
            MatchCollection matches = regex.Matches(input);
            //Loop though matches backwards so the index values don't get misaligned
            for (int i = matches.Count - 1; i >= 0; i--)
            {
                //Get the capture group info for the content between the single quotes
                Group captureGroup = matches[i].Groups[1];
                //Replace the contents of the input string with some updated value
                input = input.Substring(0, captureGroup.Index) + SomeStringMethod(captureGroup.Value) + input.Substring(captureGroup.Index + captureGroup.Length);
            }
            Console.WriteLine(input);
`
