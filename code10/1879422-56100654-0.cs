c#
Vector3 endPos;
Vector3[] points;
private void SmallestAngle()
{
    if(points.Length <2)
    {
        Debug.LogError("There should be more than two points!");
        return;
    }
    float deg = float.PositiveInfinity;
    int index = 0;
    for (int i = 0; i < points.Length; i++)
    {
        
        float d = Vector3.Angle(points[i], endPos);
        if (d < deg)
        {
            deg = d;
            index = i;
        }
    }
    Debug.Log($"Smallest angle = {deg} / Index = {index}");
}
