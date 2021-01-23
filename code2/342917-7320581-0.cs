    var task1 = Task.Factory.StartNew(() => results.LeftFront.CalcAi());
    var task2 = Task.Factory.StartNew(() => results.RightFront.CalcAi());
    var task3 = Task.Factory.StartNew(() =>results.RearSuspension.CalcAi(geom, 
                                  vehDef.Geometry.LTa.TaStiffness, 
                                  vehDef.Geometry.RTa.TaStiffness));
    
    Task.WaitAll(new []{taks1, task2, task3});
