c#
XYZ pickPoint;
using (Transaction t = new Transaction(Document))
{
    t.Start("Test Transaction");
    SketchPlane sp = SketchPlane.Create(Document, Plane.CreateByNormalAndOrigin(
        Document.ActiveView.ViewDirection,
        Document.ActiveView.Origin));
    Document.ActiveView.SketchPlane = sp;
    // Finally, we are able to PickPoint()
    pickPoint = Document.Selection.PickPoint();
    // Don't forget to clean up
    Document.Delete(sp.Id);
    t.Commit();
}
// Draw whatever you want with this point now.
Hope this helps someone out.
