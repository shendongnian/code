    Parallel.Invoke(
        () => results.LeftFront.CalcAi(),
        () => results.RightFront.CalcAi(),
        () => results.RearSuspension.CalcAi(geom, 
                                            vehDef.Geometry.LTa.TaStiffness, 
                                            vehDef.Geometry.RTa.TaStiffness));
