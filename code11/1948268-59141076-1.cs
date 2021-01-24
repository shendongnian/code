     // Define the mirror line
            Point3d acPtFrom = new Point3d(0, 4.25, 0);
            Point3d acPtTo = new Point3d(4, 4.25, 0);
            Line3d acLine3d = new Line3d(acPtFrom, acPtTo);
            // Mirror the polyline across the X axis
            acPolyMirCopy.TransformBy(Matrix3d.Mirroring(acLine3d));
            // Add the new object to the block table record and the transaction
            acBlkTblRec.AppendEntity(acPolyMirCopy);
            acTrans.AddNewlyCreatedDBObject(acPolyMirCopy, true);
