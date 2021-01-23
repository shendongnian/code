    PointD[] pts = new PointD[] { new PointD { X = 1, Y = 1 }, 
                                        new PointD { X = 1, Y = 2 }, 
                                        new PointD { X = 2, Y = 2 }, 
                                        new PointD { X = 2, Y = 3 },
                                        new PointD { X = 3, Y = 3 },
                                        new PointD { X = 3, Y = 1 }};
            List<bool> lst = new List<bool>();
            lst.Add(pnpoly(pts, new PointD { X = 2, Y = 2 }));
            lst.Add(pnpoly(pts, new PointD { X = 2, Y = 1.9 }));
            lst.Add(pnpoly(pts, new PointD { X = 2.5, Y = 2.5 }));
            lst.Add(pnpoly(pts, new PointD { X = 1.5, Y = 2.5 }));
            lst.Add(pnpoly(pts, new PointD { X = 5, Y = 5 }));
