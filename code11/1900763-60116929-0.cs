    using NetTopologySuite.Features;
    using NetTopologySuite.Geometries;
    using NetTopologySuite.IO;
    using ProjNet;
    using System;
    using System.Collections.Generic;
    using System.IO;
          
    public static void TestCreate2Dshape(string shapeFileName)
            {
                int srid = 4326;
                var sequenceFactory = new NetTopologySuite.Geometries.Implementation.DotSpatialAffineCoordinateSequenceFactory(Ordinates.XY);
                var geomFactory = new GeometryFactory(new PrecisionModel(PrecisionModels.Floating), srid, sequenceFactory);
    
                // use shapefilewriter to force geometryType a u want ex=point
                var tmpFile = System.IO.Path.GetTempFileName();
                ShapefileWriter shpWriter = new ShapefileWriter(geomFactory, tmpFile,ShapeGeometryType.Point);
    
                // use the dataWriter to write the shape file with geometry and data
                ShapefileDataWriter dataWriter = new ShapefileDataWriter(shapeFileName, geomFactory);                 
    
                // create an entity and add to the features
                List<Feature> features = new List<Feature>();
                AttributesTable att = new AttributesTable();
                att.Add("ID", 1);
                var geomZ = geomFactory.CreatePoint(new Coordinate(0,0)) ;
    
                // force geomz to geom xy using the shpWriter
                var geom = shpWriter.Factory.CreateGeometry(geomZ);
    
                // add to the features
                features.Add(new Feature(geom, att));
    
                // header
                DbaseFileHeader outDbaseHeader = new DbaseFileHeader();
                outDbaseHeader.AddColumn("ID", 'N', 10, 0);
                outDbaseHeader = ShapefileDataWriter.GetHeader(outDbaseHeader.Fields, Math.Max(features.Count, 1));
                dataWriter.Header = outDbaseHeader;
    
                // write the shapefile
                dataWriter.Write(features);
                
                // Create the projection file if necessary, choose value matching srid  
                using (StreamWriter streamWriter = new StreamWriter(shapeFileName+".prj"))
                {
                    streamWriter.Write(ProjNet.CoordinateSystems.GeographicCoordinateSystem.WGS84.WKT);
                }
    
                // delete the temporary writer
                shpWriter.Close();
                System.IO.File.Delete(tmpFile + ".shp");
                System.IO.File.Delete(tmpFile + ".shx");
            }
