csharp
// Note: Utility isn't a great name either, but definitely lose the "cls" prefix.
class Utility
{
    public int UtilityId { get; set; }
    public float[] InterpolationFactorMonth { get; } = new float[13];
}
This declares a read-only property of type `float[]`, and initializes it with a new array of 13 elements.
