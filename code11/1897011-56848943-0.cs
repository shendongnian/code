 c#
[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
public class FeatureFlagAttribute : ActionFilterAttribute
{
    public FeatureFlagAttribute(string featureName)
    {
        selectedFeature = featureName;
    }
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        if (IsActive?.Invoke(selectedFeature) == false)
        {
            // dont continue
            context.HttpContext.Response.StatusCode = 403;
        }
    }
    public static event Func<string, bool> IsActive;
}
(note that you need to be careful with static events not to cause memory leaks)
---
Alternatively, keep what you have, but make the dictionary static (and thread-protected, etc); then add some kind of API like:
 c#
public static void SetFeatureEnabled(string featureName, bool enabled);
that tweaks the static dictionary.
