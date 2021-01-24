    //this is how i print the x coordinates of all points
    using (model)
            {
                var walls = model.Instances.OfType<IIfcWall>();
                foreach (var wall in walls)
                {
                    var loop = wall.Representation.Representations[1].Items[0];
                    
                    if (loop is IfcFacetedBrep)
                    {
                        
                        var _loop = loop as IfcFacetedBrep;
                        foreach (var face in _loop.Outer.CfsFaces)
                        {
                            foreach (var bound in face.Bounds)
                            {
                                var _b = bound.Bound as IIfcPolyLoop;
                                foreach (var point in _b.Polygon)
                                {
                                    Debug.WriteLine(point.ToString());
                                }
                            }
                        }
                    }
                }
            }
