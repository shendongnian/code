c#
using (var image = new Image<Rgba32>(800, 800))
{
    var builder = new AffineTransformBuilder()
            .AppendSkewDegrees(10F, 5F)
            .AppendRotationDegrees(45F);
    var rectangle = new Rectangle(0, 0, 150, 150);
    var polygon = new RectangularPolygon(rectangle);
    Matrix3x2 matrix = builder.BuildMatrix(rectangle);
    image.Mutate(x => x.Draw(
        Rgba32.Red,
        10,
        polygon.Transform(matrix)));
    image.Save("test.bmp");
}
