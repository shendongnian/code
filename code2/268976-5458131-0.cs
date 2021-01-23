    string input = GetInput();
    string remainingPart = input.Substring(1); // get string without first character
    switch (input[0])
    {
        case 'R':
            {
                DoSomething(remainingPart);
                break;
            }
        case 'T':
            {
                DoSomethingElse(remainingPart);
                break;
            }
        default:
            {
                break;
            }
    }
