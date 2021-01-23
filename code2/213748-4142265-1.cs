    // Your collection of bits
    bool a = false, b = false, c = false;
    // get them into an array
    bool[] d = new bool[] { a, b, c };
    // intialize BitArray with that array
    System.Collections.BitArray e = new System.Collections.BitArray(d);
    // use OfType<>, Any<>, All<>
    if (Convert.ToBoolean(e.OfType<bool>().Any<bool>(condition => condition.Equals(true)) && e.OfType<bool>().Any<bool>(condition => condition.Equals(false)))) Console.WriteLine("some one is TRUE!.");
