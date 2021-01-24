using (var trMoveToOrigin = db.TransactionManager.StartTransaction())
{
// Get the extents points 
// of the selected objects.
var extPts = trMoveToOrigin.GetExtents(objIdArray);
var minExPt = extPts.MinPoint;
// Get vector from minimal extent point
// to the origin point, that will be
// used to move the selected objects.
Vector3d acVec3d = minExPt.GetVectorTo(Point3d.Origin);
foreach (ObjectId objId in objIds)
{
    Entity e = trMoveToOrigin.GetObject(objId, OpenMode.ForWrite) as Entity;
    e.TransformBy(Matrix3d.Displacement(acVec3d));
}
// Create a new external database, where the
// exported objects will be created.
using (var newDb = new Database(true, false))
{
    using (var trExport = db.TransactionManager.StartTransaction())
    {
        db.Wblock(newDb, objIds, Point3d.Origin,
                            DuplicateRecordCloning.Ignore);
        newDb.SaveAs(FileName, DwgVersion.Newest);
        trExport.Commit();
    }
}
// Dispose without commit, because the
// objects need to be in your original point
// at the end of the program.
trMoveToOrigin.Dispose();
}
