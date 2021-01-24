        enum CurrentField
        {
            FirstNum,
            SecondNum,
            UnwantedZero
        };
        static string ConvertStateMachine(string input)
        {
            // Pre-allocate enough space in the string builder.
            var numbers = new StringBuilder(input.Length);
            var state = CurrentField.FirstNum;
            int i = 0;
            while (i < input.Length)
            {
                char c = input[i++];
                switch (state)
                {
                    // Copying the first number to the output, next will be another number
                    case CurrentField.FirstNum:
                        if (c == ',')
                        {
                            // Separate the two numbers by space instead of comma, then move on
                            numbers.Append(' ');
                            state = CurrentField.SecondNum;
                        }
                        else if (!(c == ' ' || c == '\n'))
                        {
                            // Ignore whitespace, output anything else
                            numbers.Append(c);
                        }
                        break;
                    // Copying the second number to the output, next will be the ,0\n that we don't need
                    case CurrentField.SecondNum:
                        if (c == ',')
                        {
                            numbers.Append(", ");
                            state = CurrentField.UnwantedZero;
                        }
                        else if (!(c == ' ' || c == '\n'))
                        {
                            // Ignore whitespace, output anything else
                            numbers.Append(c);
                        }
                        break;
                    case CurrentField.UnwantedZero:
                        // Output nothing, just track when the line is finished and we start all over again.
                        if (c == '\n')
                        {
                            state = CurrentField.FirstNum;
                        }
                        break;
                }
            }
            return numbers.ToString();
        }
