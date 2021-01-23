    glow = placeDataList.AsParallel().Select(city =>
                                                {
                                                    var cityPop = Convert.ToDouble(city[2]);
                                                    var cityLat = Convert.ToDouble(city[3]);
                                                    var cityLon = Convert.ToDouble(city[4]);
                                                    var d = distance(testLat,
                                                                    testLon,
                                                                    cityLat,
                                                                    cityLon,
                                                                    "M");
                                                    double glowComponent = 0.0;
                                                    if (d < 150)
                                                    {
                                                        glowComponent = (0.01*cityPop*Math.Pow(d, -2.5));
                                                    }
                                                    return glowComponent;
                                                }).Sum();
