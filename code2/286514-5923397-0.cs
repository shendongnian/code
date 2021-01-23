                        var maxDist = (int) Math.Floor(maxDistance);
                        //Find the lowest possible value for X
                        var minX = Math.Min(0, xOrigin - maxDist);
                        //Find the highest possible value for X
                        var maxX = Math.Min(MaxX, xOrigin + maxDist);
                        for (var x = minX; x <= maxX; ++x){
                            //Get the possible values for Y with the current X
                            var ys = points[x];
                            if (ys.Length > 0){
                                //Calculate the max delta for Y
                                var maxYDist =(int)Math.Floor(Math.Sqrt(maxDistance*maxDistance - x*x));
                                //Find the lowest possible Y for the current X
                                var minY = Math.Min(0, yOrigin - maxYDist);
                                //Find the highest possible Y for the current X
                                var maxY = Math.Min(ys.Length, yOrigin + maxYDist);
                                for (var y = minY; y <= maxY; ++y){
                                    //The value in the array will be true if a point with the combination (x,y,) exists
                                    if (ys[y]){
                                        yield return new KeyValuePair<int, int>(x, y);
                                    }
                                }
                            }
                        }
                    }`
