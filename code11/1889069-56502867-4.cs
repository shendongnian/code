    var characters = input.ToCharArray();
    var results = new List<string>();
    var current = string.Empty;
    // 0 = not inside quotes, we expect +
    // 1 = not inside quotes, we expect "
    // 2 = inside quotes
    var state = 1;
    foreach (var character in characters)
    {
        switch (state)
        {
            case 0:
                // We are not inside quotes, we expect +
                if (character == '+')
                {
                    state = 1;
                    continue;
                }
                if (char.IsWhiteSpace(character))
                {
                    continue;
                }
                // error?
                break;
            case 1:
                // We are not inside quotes, we expect "
                if (character == '\"')
                {
                    state = 2;
                    continue;
                }
                if (char.IsWhiteSpace(character))
                {
                    continue;
                }
                // error?
                break;
            case 2:
                // We are inside quotes, we expect "
                if (character == '\"')
                {
                    state = 0;
                    results.Add(current);
                    current = string.Empty;
                    continue;
                }
                current += character;
                break;
            default:
                // error?
                break;
        }
    }
    if (state != 0)
    {
        // error
    }
    // You can use results.ToArray();
