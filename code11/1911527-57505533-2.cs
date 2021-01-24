csharp
using System.Linq; //don't forget to include LINQ
//Define the points you want to snap to
float[] segmentPositions = new float[28] { 0f, 12f, 25f, 37.5f, 50f, 62.3f, 75.35f, 88.5f, 100.8f, 114f, 127f,
                                        140f, 153f, 166.5f, 180f, 193f, 206f, 219f, 232f, 245f, 258.2f, 271.4f,
                                        283.8f, 297f, 309.5f, 322f, 334.2f, 347f };
void Start()
{
    //Get the closest segment based on the current z rotation
    //rotation.z is in radians. Since we defined our snapping points in degrees we need to 
    //convert using Matf.Rad2Deg.
    var newZRotation = GetClosestSegment(transform.rotation.z * Mathf.Rad2Deg); 
    //Alternatively we can pass in the localEulerAngles instead
    var newZRotation = GetClosestSegment(transform.localEulerAngles.z);
    //Apply the z rotation to your object here
}
private float GetClosestSegment(float input)
{
    //Get the closest point inside segmentPositions and return it
    return segmentPositions.OrderBy(s => Mathf.Abs(s - input)).First();
}
Note that this will throw a null reference if the Array is empty. so if you can't guarantee that the array is always filled make sure you perform a null check
