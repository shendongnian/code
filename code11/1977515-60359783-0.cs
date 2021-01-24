// Checks if the phone number is 10 digits.
public static bool IsPhoneNumber(string number)
{
    return Regex.Match(number, @"^([0-9]{10})$").Success;
}
And iterate over the original array you have. If you find a bad number, put it in your bad list, good number goes to good list.
List<string> mobNumbers = mob.Split(',').ToList();
List<string> goodNumbers = new List<string>();
List<string> badNumbers = new List<string>();
mobNumbers.ForEach(x => IsPhoneNumber(x) ? goodNumbers.Add(x) : badnumbers.Add("-1"));
