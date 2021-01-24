private List<Box> Split(Box box)
{
    List<Box> boxes = new List<Box>();
    foreach(Point3d corner in box.GetCorners())
    {
        Box newbox = CreateBoxFromPlaneAndTwoCorners(box.Plane, box.Center, corner);
        boxes.Add(newbox);
    }
    return boxes;
}
private Box CreateBoxFromPlaneAndTwoCorners(Plane plane, Point3d cornerA, Point3d cornerB) {
    plane.RemapToPlaneSpace(cornerA, out Point3d remapA);
    plane.RemapToPlaneSpace(cornerB, out Point3d remapB);
    Interval intX = new Interval(remapA.X,remapB.X);
    Interval intY = new Interval(remapA.Y,remapB.Y);
    Interval intZ = new Interval(remapA.Z,remapB.Z);
    return new Box(plane,intX,intY,intZ);
}
