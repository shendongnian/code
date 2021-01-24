 c#
using System.Runtime.InteropServices;
// ...
public static bool IsFullFramework => RuntimeInformation.FrameworkDescription.StartsWith(
    ".NET Framework", StringComparison.OrdinalIgnoreCase);
public static bool IsNetCore => RuntimeInformation.FrameworkDescription.StartsWith(
    ".NET Core", StringComparison.OrdinalIgnoreCase);
is it clean? no. Will it work: yes.
