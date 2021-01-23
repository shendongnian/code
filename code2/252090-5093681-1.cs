    /// <summary>
    /// Handles a GetFeature info request and returns matching ActionID's.
    /// </summary>
    /// <param name="WMSqueryString">The WM squery string.</param>
    /// <returns>A list of matching action ID's.</returns>
    /// <exception cref="ArgumentNullException">Thrown if the X or Y point values are not supplied in the WMS GetFeatureInfo request</exception>
    /// <exception cref="ArgumentException">Thrown in the X or Y point values supplied in the WMS GetFeatureInfo request cannot be converted to valid doubles</exception>
    public List<int> GetFeatureInfoActionID(NameValueCollection WMSqueryString)
    {
        //Set the projection library environment variable used by mapscript.dll
        Environment.SetEnvironmentVariable("PROJ_LIB", ProjectionLibraryPath);
        try
        {
            List<int> resultsList = new List<int>();
            using (mapObj map = new mapObj(MapFile))
            {
                ProcessLayers(map, WMSqueryString);
                map.web.metadata.set("wms_onlineresource", WMSOnlineResourceURL);
                //Load the parameters from the wms request into the map
                using (OWSRequest request = new OWSRequest())
                {
                    for (int i = 0; i < WMSqueryString.Count; i++)
                    {
                        request.setParameter(WMSqueryString.GetKey(i), WMSqueryString.Get(i));
                    }
                    string wmsVersion = WMSqueryString["VERSION"];
                    if (wmsVersion == null || wmsVersion == string.Empty) wmsVersion = DEFAULT_WMS_VERSION;
                    map.loadOWSParameters(request, wmsVersion);
                }
                string xVal = WMSqueryString["X"];
                string yVal = WMSqueryString["Y"];
                if (xVal == null || yVal == null)
                {
                    throw new ArgumentNullException("The X or Y point value has not been suppplied in the GetFeatureInfo request");
                }
                double pointX = 0.0;
                double pointY = 0.0;
                try 
                {            
                    pointX = Convert.ToDouble(xVal);
                    pointY = Convert.ToDouble(yVal);
                }
                catch (Exception e)
                {
                    throw new ArgumentException("The X or Y point value supplied in the GetFeatureInfo request is not a valid decimal",e);
                }
                //Reproject X & Y pixel co-ordinates in map co-ordintes.
                double minX = map.extent.minx;
                double maxX = map.extent.maxx;
                double geoX = minX + ((pointX / (double)map.width) * (maxX - minX));
                double minY = map.extent.miny;
                double maxY = map.extent.maxy;
                double geoY = maxY - ((pointY / (double)map.height) * (maxY - minY));
                MS_RETURN_VALUE queryResult;
                using (pointObj point = new pointObj(geoX, geoY, 0, 0))
                {
                    queryResult = (MS_RETURN_VALUE)map.queryByPoint(point, (int)MS_QUERY_MODE.MS_QUERY_MULTIPLE, -1);
                }
                if (queryResult != MS_RETURN_VALUE.MS_SUCCESS)
                {
                    return null;
                }
                map.prepareQuery();
                for (int layerIndex = 0; layerIndex < map.numlayers; layerIndex++)
                {
                    using (layerObj layer = map.getLayer(layerIndex))
                    {
                        int resultCount = layer.getNumResults();
                        if (resultCount > 0)
                        {
                            layer.open();
                            for (int resultIndex = 0; resultIndex < resultCount; resultIndex++)
                            {
                                using (resultCacheMemberObj resultCache = layer.getResult(resultIndex))
                                {
                                    int actionID = resultCache.shapeindex;
                                    if (actionID != 0 && resultsList.Contains(actionID) == false)
                                    {
                                        resultsList.Add(actionID);
                                    }
                                }
                            }
                            layer.close();
                        }
                    }
                }
            }
            return resultsList;
        }
        catch (Exception ex)
        {
            throw;
        }
    }
