csharp
/// <summary>
/// Class for generating unique stamps (for filenames, etc.)
/// </summary>
/// <remarks>
/// Each time ToString() is called, a unique stamp is generated.
/// Stamps are guaranteed to sort alphanumerically in order of generation.
/// </remarks>
public class StampGenerator
{
  /// <summary>
  /// All the characters which could be the last character in the stamp.
  /// </summary>
  private static readonly char[] _trailingChars =
  {
    'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j',
    'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't',
    'u', 'v', 'w', 'x', 'y'
  };
  /// <summary>
  /// How many valid trailing characters there are.
  /// </summary>
  /// <remarks>Should always equal _trailingChars.Length</remarks>
  public const int TRAILING_RANGE = 25;
  /// <summary>
  /// Maximum length of the stamp. Hard-coded for laziness.
  /// </summary>
  public const int MAX_LENGTH_STAMP = 28;
  /// <summary>
  /// Base portion of the stamp. Will be constant between calls.
  /// </summary>
  /// <remarks>
  /// This is intended to uniquely distinguish between instances.
  /// Default behavior is to generate a minute-accurate timestamp.
  /// </remarks>
  public string StampBase { get; }
  /// <summary>
  /// Number of times this instance has been called.
  /// </summary>
  public int CalledTimes { get; private set; }
  /// <summary>
  /// Maximum number of stamps that can be generated with a given base.
  /// </summary>
  public int MaxCalls { get; }
  /// <summary>
  /// Number of stamps remaining for this instance.
  /// </summary>
  public int RemainingCalls { get { return MaxCalls - CalledTimes; } }
  /// <summary>
  /// Instantiate a StampGenerator with a specific base.
  /// </summary>
  /// <param name="stampBase">Base of stamp.</param>
  /// <param name="calledTimes">
  /// Number of times this base has already been used.
  /// </param>
  public StampGenerator(string stampBase, int calledTimes = 0)
  {
    if (stampBase == null)
    {
      throw new ArgumentNullException("stampBase");
    }
    else if (Regex.IsMatch(stampBase, "[^a-zA-Z_0-9 \\-]"))
    {
      throw new ArgumentException("Invalid characters in Stamp Base.",
                                  "stampBase");
    }
    else if (stampBase.Length >= MAX_LENGTH_STAMP - 1)
    {
      throw new ArgumentException(
        string.Format("Stamp Base too long. (Length {0} out of {1})",
                      stampBase.Length, MAX_LENGTH_STAMP - 1), "stampBase");
    }
    else if (calledTimes < 0)
    {
      throw new ArgumentOutOfRangeException(
        "calledTimes", calledTimes, "calledTimes cannot be negative.");
    }
    else
    {
      int maxCalls = TRAILING_RANGE * (MAX_LENGTH_STAMP - stampBase.Length);
      if (calledTimes >= maxCalls)
      {
        throw new ArgumentOutOfRangeException(
          "calledTimes", calledTimes, string.Format(
            "Called Times too large; max for stem of length {0} is {1}.",
            stampBase.Length, maxCalls));
      }
      else
      {
        StampBase = stampBase;
        CalledTimes = calledTimes;
        MaxCalls = maxCalls;
      }
    }
  }
  /// <summary>
  /// Instantiate a StampGenerator with default base string based on time.
  /// </summary>
  public StampGenerator() : this(DateTime.Now.ToString("yMMddHHmm")) { }
  /// <summary>
  /// Generate a unique stamp.
  /// </summary>
  /// <remarks>
  /// Stamp values are orered like this:
  /// a, b, ... x, y, za, zb, ... zx, zy, zza, zzb, ...
  /// </remarks>
  /// <returns>A unique stamp.</returns>
  public override string ToString()
  {
    int zCount = CalledTimes / TRAILING_RANGE;
    int trailing = CalledTimes % TRAILING_RANGE;
    int length = StampBase.Length + zCount + 1;
    if (length > MAX_LENGTH_STAMP)
    {
      throw new InvalidOperationException(
        "Stamp length overflown! Cannot generate new stamps.");
    }
    else
    {
      CalledTimes = CalledTimes + 1;
      var builder = new StringBuilder(StampBase, length);
      builder.Append('z', zCount);
      builder.Append(_trailingChars[trailing]);
      return builder.ToString();
    }
  }
}
