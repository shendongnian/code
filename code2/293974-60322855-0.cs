/// <summary>
/// Calculate the magnitude / length of a vector, including the W component.
/// </summary>
/// <remarks>
/// This calculation will break down if you try to take the magnitude of a point.
/// </remarks>
/// <returns>The magnitude / length of the vector.</returns>
public float Magnitude()
{
	return (float)Math.Sqrt(X * X + Y * Y + Z * Z + W * W);
}
