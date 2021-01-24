csharp
GameObject[] FindGameObjectsWithTags(params string[] tags)
{
    var all = new List<GameObject>();
    foreach (string tag in tags)
    {
        all.AddRange(GameObject.FindGameObjectsWithTag(tag).ToList());
    }
    return all.ToArray();
}
**EDITED : Typo**
