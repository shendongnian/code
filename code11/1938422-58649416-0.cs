    var x = 121;
    var numba = x.ToString();
    // Get the length of half the string
    int halfLength = numba.Length / 2;
    // Start assuming it is a palindrome
    bool isPalindrome = true;
    // Compare a character from the beginning of the string
    // with it's corresponding character at the end. If the
    // characters do not match, it's not a palindrome.
    for (int i = 0; i < halfLength; i++)
    {
        if (numba[i] != numba[numba.Length - i - 1])
        {
            // The characters don't match, it's not a palindrome
            isPalindrome = false;
            break;
        }
    }
    // Output the result
    Console.WriteLine(isPalindrome);
