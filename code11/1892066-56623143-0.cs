    var geoStates = (from gs in QBEntities.GeoStates
                     select new
                     {
                         gs.GEOID,
                         gs.GEO_NAME,
                         SpatialTypeName = gs.GEO_OBJECT.SpatialTypeName,
                         gs.JSON_GEOMETRY
                     }).ToList();
                       
    _MapData.features = (from gs in geoStates
                         select new MapDataRecord
                         {
                             properties = new MapDataRecordProperties
                             {
                                 GEOID = gs.GEOID,
                                 GEO_NAME = gs.GEO_NAME
                             },
                             geometry = SetGeoJsonGeography(gs.SpatialTypeName, gs.JSON_GEOMETRY)
                         }).ToList();
