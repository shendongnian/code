C#
private static void DrawDebugFrames(List<LogoPlacementContentDto> placements, Image<Rgba32> mutatedImage)
{
    foreach (var placement in placements)
    {
        var width = placement.WidthInt;
        var height = placement.HeightInt;
        using (var logo = new Image<Rgba32>(Configuration.Default, width, height))
        {
            var positionX = placement.Position.X;
            var positionY = placement.Position.Y;
            var affineBuilder = new AffineTransformBuilder();
            affineBuilder.PrependTranslation(new Vector2(positionX, positionY));
            affineBuilder.PrependRotationDegrees(placement.Rotation);
            affineBuilder.AppendTranslation(new Vector2(-positionX, -positionY));
            logo.Mutate(
                x => x
                    .BackgroundColor(Rgba32.Beige).DrawPolygon(
                        Rgba32.HotPink,
                        4,
                    new Vector2(0, 0),
                    new Vector2(width, 0),
                    new Vector2(width, height),
                    new Vector2(0, height)
                    )
                    .Transform(affineBuilder)
            );
            mutatedImage.Mutate(
                x => x
                    .DrawImage(logo, new Point(placement.Position.XInt, placement.Position.YInt), GraphicsOptions.Default)
            );
        }
    }
}
