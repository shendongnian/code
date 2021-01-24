        var model = new MeshGeometryModel3D()
        {
            Material = CastMaterial(gm3D.Material),
            Transform = m3d.Transform,
            Geometry = meshGeometry,
            CullMode = CullMode.Front
        };
        obCollection.Add(model);
