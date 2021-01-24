    using NetTopologySuite.IO;
    using NetTopologySuite.Geometries;
    using GeoJSON.Net.Feature;
    using GeoJSON.Net;
    
    [HttpPost]
    public void GeoJson(string json) {
     var test = json;
     var item = JObject.Parse(json);
    
     Species newSpecies = new Species();
    
     var reader = new GeoJsonReader();
     var featureCollection = reader.Read < FeatureCollection > (json);
    
     if (featureCollection == null) {
      return;
     }
    
     // loop through all the parsed features
     for (int featureIndex = 0; featureIndex < featureCollection.Features.Count; featureIndex++) {
      // get json feature
      var jsonFeature = featureCollection.Features[featureIndex];
    
      // get geometry type to create appropriate geometry
      switch (jsonFeature.Geometry.Type) {
       case GeoJSONObjectType.Point:
        break;
       case GeoJSONObjectType.MultiPoint:
        break;
       case GeoJSONObjectType.LineString:
        break;
       case GeoJSONObjectType.MultiLineString:
        break;
       case GeoJSONObjectType.Polygon:
        break;
        //ovo trenutno ima smisla samo ako se distribucija prikazuje samo kao jedan Feature u FeatureListi
        //moram razmisliti kako to napraviti ako je slučaj više multipoligona i kako ih kombinirati
       case GeoJSONObjectType.MultiPolygon:
        {
         var multipoly = jsonFeature.Geometry as GeoJSON.Net.Geometry.MultiPolygon;
         var polygonList = new List < Polygon > ();
         foreach(var firstLevel in multipoly.Coordinates) {
          var firstLevelCoordinateList = new List < List < Coordinate >> ();
    
          foreach(var secondLevel in firstLevel.Coordinates) {
    
           var secondLevelCoordinateList = new List < Coordinate > ();
           foreach(var thirdLevel in secondLevel.Coordinates) {
            var coordinates = new Coordinate(thirdLevel.Longitude, thirdLevel.Latitude);
            secondLevelCoordinateList.Add(coordinates);
           }
    
           var coordArr = new Coordinate[secondLevelCoordinateList.Count];
    
           for (int i = 0; i < secondLevelCoordinateList.Count; i++) {
            coordArr[i] = secondLevelCoordinateList[i];
           }
           var poly = new GeometryFactory().CreatePolygon(coordArr);
           polygonList.Add(poly);
           firstLevelCoordinateList.Add(secondLevelCoordinateList);
          }
    
         }
         var polyArr = new Polygon[polygonList.Count];
    
         for (int i = 0; i < polygonList.Count; i++) {
          polyArr[i] = polygonList[i];
         }
         //NetTopologySuite Multipolygon property
         newSpecies.Range = new GeometryFactory().CreateMultiPolygon(polyArr);
        }
        break;
       case GeoJSONObjectType.GeometryCollection:
        break;
       case GeoJSONObjectType.Feature:
        break;
       case GeoJSONObjectType.FeatureCollection:
        break;
       default:
        throw new ArgumentOutOfRangeException();
      }
     }
    }
