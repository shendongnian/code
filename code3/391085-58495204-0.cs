 csharp
///<completionlist cref="HexColor"/> 
class HexColor : StringEnum<HexColor>
{
    public static readonly HexColor Blue = New("#FF0000");
    public static readonly HexColor Green = New("#00FF00");
    public static readonly HexColor Red = New("#000FF");
}
## Features
- Your StringEnum looks somewhat similar to a regular enum:
 csharp
    // Static Parse Method
    HexColor.Parse("#FF0000") // => HexColor.Red
    HexColor.Parse("#ff0000", caseSensitive: false) // => HexColor.Red
    HexColor.Parse("invalid") // => throws InvalidOperationException
    // Static TryParse method.
    HexColor.TryParse("#FF0000") // => HexColor.Red
    HexColor.TryParse("#ff0000", caseSensitive: false) // => HexColor.Red
    HexColor.TryParse("invalid") // => null
    // Parse and TryParse returns the preexistent instances
    object.ReferenceEquals(HexColor.Parse("#FF0000"), HexColor.Red) // => true
    // Conversion from your `StringEnum` to `string`
    string myString1 = HexColor.Red.ToString(); // => "#FF0000"
    string myString2 = HexColor.Red; // => "#FF0000" (implicit cast)
- Intellisense will suggest the enum name if the class is annotated with the xml comment `<completitionlist>`. (Works in both C# and VB): i.e.
![Intellisense demo](https://raw.githubusercontent.com/gerardog/StringEnum/master/images/intellisense.gif)
## Instalation
Either:
- Install latest [**StringEnum**](https://www.nuget.org/packages/StringEnum/) NuGet package, which is based on `.Net Standard 1.0` so it runs on `.Net Core` >= 1.0, `.Net Framework` >= 4.5, `Mono` >= 4.6, etc.
- Or paste the following StringEnum base class to your project. ([latest version](https://github.com/gerardog/StringEnum/blob/master/StringEnum/StringEnum.cs))
 csharp
    public abstract class StringEnum<T> : IEquatable<T> where T : StringEnum<T>, new()
    {
        protected string Value;
        private static IList<T> valueList = new List<T>();
        protected static T New(string value)
        {
            if (value == null)
                return null; // the null-valued instance is null.
            var result = new T() { Value = value };
            valueList.Add(result);
            return result;
        }
        public static implicit operator string(StringEnum<T> enumValue) => enumValue.Value;
        public override string ToString() => Value;
        public static bool operator !=(StringEnum<T> o1, StringEnum<T> o2) => o1?.Value != o2?.Value;
        public static bool operator ==(StringEnum<T> o1, StringEnum<T> o2) => o1?.Value == o2?.Value;
        public override bool Equals(object other) => this.Value.Equals((other as T)?.Value ?? (other as string));
        bool IEquatable<T>.Equals(T other) => this.Value.Equals(other.Value);
        public override int GetHashCode() => Value.GetHashCode();
        /// <summary>
        /// Parse the <paramref name="value"/> specified and returns a valid <typeparamref name="T"/> or else throws InvalidOperationException.
        /// </summary>
        /// <param name="value">The string value representad by an instance of <typeparamref name="T"/>. Matches by string value, not by the member name.</param>
        /// <param name="caseSensitive">If true, the strings must match case sensitivity.</param>
        public static T Parse(string value, bool caseSensitive = false)
        {
            var result = TryParse(value, caseSensitive);
            if (result == null)
                throw new InvalidOperationException((value == null ? "null" : $"'{value}'") + $" is not a valid {typeof(T).Name}");
            return result;
        }
        /// <summary>
        /// Parse the <paramref name="value"/> specified and returns a valid <typeparamref name="T"/> or else returns null.
        /// </summary>
        /// <param name="value">The string value representad by an instance of <typeparamref name="T"/>. Matches by string value, not by the member name.</param>
        /// <param name="caseSensitive">If true, the strings must match case sensitivity.</param>
        public static T TryParse(string value, bool caseSensitive = false)
        {
            if (value == null) return null;
            if (valueList.Count == 0) System.Runtime.CompilerServices.RuntimeHelpers.RunClassConstructor(typeof(T).TypeHandle); // force static fields initialization
            var field = valueList.FirstOrDefault(f => f.Value.Equals(value,
                    caseSensitive ? StringComparison.Ordinal
                                  : StringComparison.OrdinalIgnoreCase));
            // Not using InvariantCulture because it's only supported in NETStandard >= 2.0
            if (field == null)
                return null;
            return field;
        }
    }
- For `Newtonsoft.Json` serialization support, copy this extended version instead. [StringEnum.cs](https://github.com/gerardog/StringEnum/blob/master/StringEnum.Sample.NewtonsoftSerialization/StringEnum.cs)
I realized after the fact that this code is similar to Ben's answer. I sincerely wrote it from scratch. However I think it has a few extras, like the `<completitionlist>` hack, the resulting class looks more like an Enum, no use of reflection on Parse(), the NuGet package and repo where I will hopefully address incoming issues and feedback.
