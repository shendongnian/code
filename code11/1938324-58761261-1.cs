c#
private static void ResizeAndSavePhoto(Image<Rgba32> img, string path, int squareSize)
{
    img.Mutate(x =>
        x.Resize(new ResizeOptions
        {
            Size = new Size(squareSize, squareSize),
            Mode = ResizeMode.Pad
        }).BackgroundColor(new Rgba32(255, 255, 255, 0)));
    // The following demonstrates how to force png encoding with a path.
    img.Save(Path.ChangeExtension(path, ".jpg"))
    img.Save(path, new PngEncoder());
}
Additionally, if saving to a stream.
 c#
img.SaveAsPng(path);
