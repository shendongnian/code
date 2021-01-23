    static void Main(string[] args)
    {
        Console.WriteLine(OctetInIP("10.1.1.100", 0));
        Console.ReadLine();
    }
    static byte OctetInIP(string ip, int octet)
    {
        var octCount = 0;
        var result = 0;
        // Loop through each character.
        for (var i = 0; i < ip.Length; i++)
        {
            var c = ip[i];
            // If we hit a full stop.
            if (c == '.')
            {
                // Return the value if we are on the correct octet.
                if (octCount == octet)
                    return (byte)result;
                octCount++;
            }
            else if (octCount == octet)
            {
                // Convert the current octet to a number.
                result *= 10;
                switch (c)
                {
                    case '0': break;
                    case '1': result += 1; break;
                    case '2': result += 2; break;
                    case '3': result += 3; break;
                    case '4': result += 4; break;
                    case '5': result += 5; break;
                    case '6': result += 6; break;
                    case '7': result += 7; break;
                    case '8': result += 8; break;
                    case '9': result += 9; break;
                    default:
                        throw new FormatException();
                }
                if (result > 255)
                    throw new FormatException();
            }
        }
        if (octCount != octet)
            throw new FormatException();
        return (byte)result;
    }
