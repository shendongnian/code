c#
public class SomeGameClass
{
	private bool isRunning;
	private int counter;
	private int DoSomething()
	{
		if (isRunning)
		{
			counter++;
			return counter * 10;
		}
	}
}
**Patching with Harmony annotations**
c#
using SomeGame;
using Harmony;
public class MyPatcher
{
	// make sure DoPatching() is called at start either by
	// the mod loader or by your injector
	public static void DoPatching()
	{
		var harmony = new Harmony("com.example.patch");
		harmony.PatchAll();
	}
}
[HarmonyPatch(typeof(SomeGameClass))]
[HarmonyPatch("DoSomething")]
class Patch01
{
	static FieldRef<SomeGameClass,bool> isRunningRef =
		AccessTools.FieldRefAccess<SomeGameClass, bool>("isRunning");
	static bool Prefix(SomeGameClass __instance, ref int ___counter)
	{
		isRunningRef(__instance) = true;
		if (___counter > 100)
			return false;
		___counter = 0;
		return true;
	}
	static void Postfix(ref int __result)
	{
		__result *= 2;
	}
}
**Alternatively, manual patching with reflection**
c#
using SomeGame;
using Harmony;
public class MyPatcher
{
	// make sure DoPatching() is called at start either by
	// the mod loader or by your injector
	public static void DoPatching()
	{
		var harmony = new Harmony("com.example.patch");
		var mOriginal = typeof(SomeGameClass).GetMethod("DoSomething", BindingFlags.Instance | BindingFlags.NonPublic);
		var mPrefix = typeof(MyPatcher).GetMethod("MyPrefix", BindingFlags.Static | BindingFlags.Public);
		var mPostfix = typeof(MyPatcher).GetMethod("MyPostfix", BindingFlags.Static | BindingFlags.Public);
		// add null checks here
		harmony.Patch(mOriginal, new HarmonyMethod(mPrefix), new HarmonyMethod(mPostfix));
	}
	public static void MyPrefix()
	{
		// ...
	}
	public static void MyPostfix()
	{
		// ...
	}
}
  [1]: https://github.com/pardeike/Harmony
  [2]: https://harmony.pardeike.net
