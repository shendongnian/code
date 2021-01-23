    Rect3D d1 = MeshGeometry3D_1.Bounds;
    d1.Union(MeshGeometry3D_2.Bounds);
    // to the center of the block:
    Vector3D cVect = new Vector3D(d1.SizeX / 2, d1.SizeY / 2, d1.SizeZ / 2);           
    columnModel.Transform = new TranslateTransform3D(-cVect);
