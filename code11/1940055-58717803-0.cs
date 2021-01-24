csharp
string[] DifferArray = sublineArray.Except(subLineNames.Where(m => !string.IsNullOrWhiteSpace(m)).Select(m => m.Trim())).ToArray();
Better yet, you can store a reference to your sanitized parameter array:
csharp
[HttpPost]
public ActionResult MyAction(string[] subLineNames)
{
    if (subLineNames == null)
    {
        return new HttpStatusCodeResult(HttpStatusCode.BadRequest, $"You must provide {nameof(subLineNames)}.");
    }
    var sanitizedSubLineNames = subLineNames.Where(m => !string.IsNullOrWhiteSpace(m)).Select(m => m.Trim());
    var sublineArray = new string[] { "BI/PD", "Hired", "Non-Owned", "PIP", "Addtl-PIP", "Medical Payments", "UM PD", "UM CSL", "UIM CSL", "Terrorism" };
    var differArray = sublineArray.Except(sanitizedSubLineNames).ToArray();
    // Do something...
}
