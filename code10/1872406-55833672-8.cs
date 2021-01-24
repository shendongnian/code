    public static class SSASAMO
    {
        public static List<SSASObject> ReadMeta(string ServerName)
        {
            try
            {
                List<SSASObject> result = new List<SSASObject>();
                String ConnStr;
                DateTime? dt = null;
                int idx = 0;
                int DbID = 0;
                int CubeID = 0;
                int ObjectID = 0;
                string DataDir;
                string OLAPServerName = ServerName;
                ConnStr = "Provider=MSOLAP;Data Source=" + OLAPServerName + ";";
                Server OLAPServer = new Server();
                OLAPServer.Connect(ConnStr);
                DataDir = OLAPServer.ServerProperties["DataDir"].Value;
                string[] DatabasesDir = System.IO.Directory.GetDirectories(DataDir, "*", System.IO.SearchOption.TopDirectoryOnly);
                string[] DatabasesFiles = System.IO.Directory.GetFiles(DataDir, "*", System.IO.SearchOption.TopDirectoryOnly);
                result.Add(new SSASObject
                {
                    ID = idx,
                    ParentID = null,
                    FolderModifiedDate = System.IO.Directory.GetLastWriteTime(DataDir),
                    FolderPath = DataDir,
                    ObjectName = OLAPServerName,
                    Type = SSASObject.ObjectType.Server
                });
                // Database
                foreach (Database OLAPDatabase in OLAPServer.Databases)
                {
                    string CurrentDbDir = DatabasesDir.Where(x => x.StartsWith(DataDir + "\\" +  OLAPDatabase.ID.ToString() + ".") && x.EndsWith(".db")).DefaultIfEmpty("").First();
                    string CurrentDbXmlFile = DatabasesFiles.Where(x => x.StartsWith(DataDir + "\\" + OLAPDatabase.ID.ToString() + ".") && x.EndsWith(".db.xml")).DefaultIfEmpty("").First();
                    string[] DbObjectsDir = System.IO.Directory.GetDirectories(CurrentDbDir, "*", System.IO.SearchOption.TopDirectoryOnly);
                    string[] DbObjectsFiles = System.IO.Directory.GetFiles(CurrentDbDir, "*", System.IO.SearchOption.TopDirectoryOnly);
                    idx++;
                    DbID = idx;
                    result.Add(new SSASObject
                    {
                        ID = idx,
                        ParentID = 0,
                        ObjectID = OLAPDatabase.ID,
                        FolderModifiedDate = CurrentDbDir == "" ? dt : System.IO.Directory.GetLastWriteTime(CurrentDbDir),
                        XmlIncremetalID = System.IO.Path.GetFileNameWithoutExtension(
                                                      System.IO.Path.GetFileNameWithoutExtension(CurrentDbXmlFile)).Substring(
                                                      System.IO.Path.GetFileNameWithoutExtension(CurrentDbXmlFile).IndexOf(".") + 1),
                        Extension = ".db",
                        FolderName = System.IO.Path.GetFileName(CurrentDbDir),
                        FolderPath = CurrentDbDir,
                        ObjectName = OLAPDatabase.Name,
                        Type = SSASObject.ObjectType.Database,
                        XMLFileName = System.IO.Path.GetFileName(CurrentDbXmlFile),
                        XMLFilePath = CurrentDbXmlFile,
                        XmlModifiedDate = CurrentDbXmlFile == "" ? dt : System.IO.File.GetLastWriteTime(CurrentDbXmlFile),
                        FolderIncremetalID = System.IO.Path.GetFileNameWithoutExtension(CurrentDbDir).Substring(
                                                      System.IO.Path.GetFileNameWithoutExtension(CurrentDbDir).IndexOf(".") + 1)
                    });
                    //Data Source
                    foreach (DataSource OLAPDataSource in OLAPDatabase.DataSources)
                    {
                        idx++;
                        string CurrentDataSourceDir = DbObjectsDir.Where(x => x.StartsWith(CurrentDbDir + "\\" + OLAPDataSource.ID.ToString() + ".") && x.EndsWith(".ds")).DefaultIfEmpty("").First();
                        string CurrentDataSourceXmlFile = DbObjectsFiles.Where(x => x.StartsWith(CurrentDbDir + "\\" + OLAPDataSource.ID.ToString() + ".") && x.EndsWith(".ds.xml")).DefaultIfEmpty("").First();
                        result.Add(new SSASObject
                        {
                            ID = idx,
                            ParentID = DbID,
                            ObjectID = OLAPDataSource.ID,
                            FolderModifiedDate = CurrentDataSourceDir == "" ? dt : System.IO.Directory.GetLastWriteTime(CurrentDataSourceDir),
                            XmlIncremetalID = System.IO.Path.GetFileNameWithoutExtension(
                                                          System.IO.Path.GetFileNameWithoutExtension(CurrentDataSourceXmlFile)).Substring(
                                                          System.IO.Path.GetFileNameWithoutExtension(CurrentDataSourceXmlFile).IndexOf(".") + 1),
                            Extension = ".ds",
                            FolderName = System.IO.Path.GetFileName(CurrentDataSourceDir),
                            FolderPath = CurrentDbDir,
                            ObjectName = OLAPDataSource.Name,
                            Type = SSASObject.ObjectType.DataSource,
                            XMLFileName = System.IO.Path.GetFileName(CurrentDataSourceXmlFile),
                            XMLFilePath = CurrentDataSourceXmlFile,
                            XmlModifiedDate = CurrentDataSourceXmlFile == "" ? dt : System.IO.File.GetLastWriteTime(CurrentDataSourceXmlFile),
                            FolderIncremetalID = System.IO.Path.GetFileNameWithoutExtension(CurrentDataSourceDir).Substring(
                                                          System.IO.Path.GetFileNameWithoutExtension(CurrentDataSourceDir).IndexOf(".") + 1)
                        });
                    }
                    //Data Source View
                    foreach (DataSourceView OLAPDataSourceView in OLAPDatabase.DataSourceViews)
                    {
                        idx++;
                        string CurrentDataSourceViewDir = DbObjectsDir.Where(x => x.StartsWith(CurrentDbDir + "\\" + OLAPDataSourceView.ID.ToString() + ".") && x.EndsWith(".dsv")).DefaultIfEmpty("").First();
                        string CurrentDataSourceViewXmlFile = DbObjectsFiles.Where(x => x.StartsWith(CurrentDbDir + "\\" + OLAPDataSourceView.ID.ToString() + ".") && x.EndsWith(".dsv.xml")).DefaultIfEmpty("").First();
                        result.Add(new SSASObject
                        {
                            ID = idx,
                            ParentID = DbID,
                            ObjectID = OLAPDataSourceView.ID,
                            FolderModifiedDate = CurrentDataSourceViewDir == "" ? dt : System.IO.Directory.GetLastWriteTime(CurrentDataSourceViewDir),
                            XmlIncremetalID = System.IO.Path.GetFileNameWithoutExtension(
                                                          System.IO.Path.GetFileNameWithoutExtension(CurrentDataSourceViewXmlFile)).Substring(
                                                          System.IO.Path.GetFileNameWithoutExtension(CurrentDataSourceViewXmlFile).IndexOf(".") + 1),
                            Extension = ".dsv",
                            FolderName = System.IO.Path.GetFileName(CurrentDataSourceViewDir),
                            FolderPath = CurrentDbDir,
                            ObjectName = OLAPDataSourceView.Name,
                            Type = SSASObject.ObjectType.DataSourceView,
                            XMLFileName = System.IO.Path.GetFileName(CurrentDataSourceViewXmlFile),
                            XMLFilePath = CurrentDataSourceViewXmlFile,
                            XmlModifiedDate = CurrentDataSourceViewXmlFile == "" ? dt : System.IO.File.GetLastWriteTime(CurrentDataSourceViewXmlFile),
                            FolderIncremetalID = System.IO.Path.GetFileNameWithoutExtension(CurrentDataSourceViewDir).Substring(
                                                          System.IO.Path.GetFileNameWithoutExtension(CurrentDataSourceViewDir).IndexOf(".") + 1)
                        });
                    }
                    //Dimension
                    foreach (Dimension OLAPDimension in OLAPDatabase.Dimensions)
                    {
                        idx++;
                        string DimensionDir = DbObjectsDir.Where(x => x.StartsWith(CurrentDbDir + "\\" + OLAPDimension.ID.ToString() + ".") && x.EndsWith(".dim")).DefaultIfEmpty("").First();
                        string DimensionXmlFile = DbObjectsFiles.Where(x => x.StartsWith(CurrentDbDir + "\\" + OLAPDimension.ID.ToString() + ".") && x.EndsWith(".dim.xml")).DefaultIfEmpty("").First();
                        result.Add(new SSASObject
                        {
                            ID = idx,
                            ParentID = DbID,
                            ObjectID = OLAPDimension.ID,
                            FolderModifiedDate = DimensionDir == "" ? dt : System.IO.Directory.GetLastWriteTime(DimensionDir),
                            XmlIncremetalID = System.IO.Path.GetFileNameWithoutExtension(
                                                      System.IO.Path.GetFileNameWithoutExtension(DimensionXmlFile)).Substring(
                                                      System.IO.Path.GetFileNameWithoutExtension(DimensionXmlFile).IndexOf(".") + 1),
                            Extension = ".dim",
                            FolderName = System.IO.Path.GetFileName(DimensionDir),
                            FolderPath = DimensionDir,
                            ObjectName = OLAPDimension.Name,
                            Type = SSASObject.ObjectType.Dimension,
                            XMLFileName = System.IO.Path.GetFileName(DimensionXmlFile),
                            XMLFilePath = DimensionXmlFile,
                            XmlModifiedDate = DimensionXmlFile == "" ? dt : System.IO.File.GetLastWriteTime(DimensionXmlFile),
                            FolderIncremetalID = System.IO.Path.GetFileNameWithoutExtension(DimensionDir).Substring(
                                                 System.IO.Path.GetFileNameWithoutExtension(DimensionDir).IndexOf(".") + 1)
                        });
                    }
                    // Cube
                    foreach (Cube OLAPCubex in OLAPDatabase.Cubes)
                    {
                        idx++;
                        CubeID = idx;
                        string CubeDir = DbObjectsDir.Where(x => x.StartsWith(CurrentDbDir + "\\" + OLAPCubex.ID.ToString() + ".") && x.EndsWith(".cub")).DefaultIfEmpty("").First();
                        string CubeXmlFile = DbObjectsFiles.Where(x => x.StartsWith(CurrentDbDir + "\\" + OLAPCubex.ID.ToString() + ".") && x.EndsWith(".cub.xml")).DefaultIfEmpty("").First();
                        string[] CubeMeasureGroupsDir = System.IO.Directory.GetDirectories(CubeDir, "*", System.IO.SearchOption.TopDirectoryOnly);
                        string[] CubeMeasureGroupsFiles = System.IO.Directory.GetFiles(CubeDir, "*", System.IO.SearchOption.TopDirectoryOnly);
                        
                        result.Add(new SSASObject
                        {
                            ID = idx,
                            ParentID = DbID,
                            ObjectID = OLAPCubex.ID,
                            FolderModifiedDate = CubeDir == "" ? dt : System.IO.Directory.GetLastWriteTime(CubeDir),
                            XmlIncremetalID = System.IO.Path.GetFileNameWithoutExtension(
                                                      System.IO.Path.GetFileNameWithoutExtension(CubeXmlFile)).Substring(
                                                      System.IO.Path.GetFileNameWithoutExtension(CubeXmlFile).IndexOf(".") + 1),
                            Extension = ".cub",
                            FolderName = System.IO.Path.GetFileName(CubeDir),
                            FolderPath = CubeDir,
                            ObjectName = OLAPCubex.Name,
                            Type = SSASObject.ObjectType.Cube,
                            XMLFileName = System.IO.Path.GetFileName(CubeXmlFile),
                            XMLFilePath = CubeXmlFile,
                            XmlModifiedDate = CubeXmlFile == "" ? dt : System.IO.File.GetLastWriteTime(CubeXmlFile),
                            FolderIncremetalID = System.IO.Path.GetFileNameWithoutExtension(CubeDir).Substring(
                                                 System.IO.Path.GetFileNameWithoutExtension(CubeDir).IndexOf(".") + 1)
                        });
                        //Measure Group
                        foreach (MeasureGroup OLAPMeasureGroup in OLAPCubex.MeasureGroups)
                        {
                            idx++;
                            ObjectID = idx;
                            string MeasureGroupDir = CubeMeasureGroupsDir.Where(x => x.StartsWith(CubeDir + "\\" + OLAPMeasureGroup.ID.ToString() + ".") && x.EndsWith(".det")).DefaultIfEmpty("").First();
                            string MeasureGroupXmlFile = CubeMeasureGroupsFiles.Where(x => x.StartsWith(CubeDir + "\\" + OLAPMeasureGroup.ID.ToString() + ".") && x.EndsWith(".det.xml")).DefaultIfEmpty("").First();
                            string[] GroupPartitionDir = System.IO.Directory.GetDirectories(MeasureGroupDir, "*", System.IO.SearchOption.TopDirectoryOnly);
                            string[] GroupPartitionFiles = System.IO.Directory.GetFiles(MeasureGroupDir, "*", System.IO.SearchOption.TopDirectoryOnly);
                            result.Add(new SSASObject
                            {
                                ID = idx,
                                ParentID = CubeID,
                                ObjectID = OLAPMeasureGroup.ID,
                                FolderModifiedDate = MeasureGroupDir == "" ? dt : System.IO.Directory.GetLastWriteTime(MeasureGroupDir),
                                XmlIncremetalID = System.IO.Path.GetFileNameWithoutExtension(
                                                      System.IO.Path.GetFileNameWithoutExtension(MeasureGroupXmlFile)).Substring(
                                                      System.IO.Path.GetFileNameWithoutExtension(MeasureGroupXmlFile).IndexOf(".") + 1),
                                Extension = ".det",
                                FolderName = System.IO.Path.GetFileName(MeasureGroupDir),
                                FolderPath = MeasureGroupDir,
                                ObjectName = OLAPMeasureGroup.Name,
                                Type = SSASObject.ObjectType.MeasureGroup,
                                XMLFileName = System.IO.Path.GetFileName(MeasureGroupXmlFile),
                                XMLFilePath = MeasureGroupXmlFile,
                                XmlModifiedDate = MeasureGroupXmlFile == "" ? dt : System.IO.File.GetLastWriteTime(MeasureGroupXmlFile),
                                FolderIncremetalID = System.IO.Path.GetFileNameWithoutExtension(MeasureGroupDir).Substring(
                                                     System.IO.Path.GetFileNameWithoutExtension(MeasureGroupDir).IndexOf(".") + 1)
                            });
                            //Aggregations
                            foreach (AggregationDesign OLAPAggregationDesign in OLAPMeasureGroup.AggregationDesigns)
                            {
                                string AggregationDir = GroupPartitionDir.Where(x => x.StartsWith(MeasureGroupDir + "\\" + OLAPAggregationDesign.ID.ToString() + ".") && x.EndsWith(".agg")).DefaultIfEmpty("").First();
                                string AggregationXmlFile = GroupPartitionFiles.Where(x => x.StartsWith(MeasureGroupDir + "\\" + OLAPAggregationDesign.ID.ToString() + ".") && x.EndsWith(".agg.xml")).DefaultIfEmpty("").First();
                                idx++;
                                result.Add(new SSASObject
                                {
                                    ID = idx,
                                    ParentID = ObjectID,
                                    ObjectID = OLAPAggregationDesign.ID,
                                    FolderModifiedDate = AggregationDir == "" ? dt : System.IO.Directory.GetLastWriteTime(AggregationDir),
                                    XmlIncremetalID = System.IO.Path.GetFileNameWithoutExtension(
                                                      System.IO.Path.GetFileNameWithoutExtension(AggregationXmlFile)).Substring(
                                                      System.IO.Path.GetFileNameWithoutExtension(AggregationXmlFile).IndexOf(".") + 1),
                                    Extension = ".agg",
                                    FolderName = System.IO.Path.GetFileName(AggregationDir),
                                    FolderPath = AggregationDir,
                                    ObjectName = OLAPAggregationDesign.Name,
                                    Type = SSASObject.ObjectType.AggregationDesign,
                                    XMLFileName = System.IO.Path.GetFileName(AggregationXmlFile),
                                    XMLFilePath = AggregationXmlFile,
                                    XmlModifiedDate = AggregationXmlFile == "" ? dt : System.IO.File.GetLastWriteTime(AggregationXmlFile),
                                    FolderIncremetalID = System.IO.Path.GetFileNameWithoutExtension(AggregationDir).Substring(
                                                         System.IO.Path.GetFileNameWithoutExtension(AggregationDir).IndexOf(".") + 1)
                                });
                            }
                            //Partitions
                            foreach (Partition OLAPPartition in OLAPMeasureGroup.Partitions)
                            {
                                string PartitionDir = GroupPartitionDir.Where(x => x.StartsWith(MeasureGroupDir + "\\" + OLAPPartition.ID.ToString() + ".") && x.EndsWith(".prt")).DefaultIfEmpty("").First();
                                string PartitionXmlFile = GroupPartitionFiles.Where(x => x.StartsWith(MeasureGroupDir + "\\" + OLAPPartition.ID.ToString() + ".") && x.EndsWith(".prt.xml")).DefaultIfEmpty("").First();
                                
                                idx++;
                                result.Add(new SSASObject
                                {
                                    ID = idx,
                                    ParentID = ObjectID,
                                    ObjectID = OLAPPartition.ID,
                                    FolderModifiedDate = PartitionDir == "" ? dt : System.IO.Directory.GetLastWriteTime(PartitionDir),
                                    XmlIncremetalID = System.IO.Path.GetFileNameWithoutExtension(
                                                      System.IO.Path.GetFileNameWithoutExtension(PartitionXmlFile)).Substring(
                                                      System.IO.Path.GetFileNameWithoutExtension(PartitionXmlFile).IndexOf(".") + 1),
                                    Extension = ".prt",
                                    FolderName = System.IO.Path.GetFileName(PartitionDir),
                                    FolderPath = PartitionDir,
                                    ObjectName = OLAPPartition.Name,
                                    Type = SSASObject.ObjectType.Partition,
                                    XMLFileName = System.IO.Path.GetFileName(PartitionXmlFile),
                                    XMLFilePath = PartitionXmlFile,
                                    XmlModifiedDate = PartitionXmlFile == "" ? dt : System.IO.File.GetLastWriteTime(PartitionXmlFile),
                                    FolderIncremetalID = System.IO.Path.GetFileNameWithoutExtension(PartitionDir).Substring(
                                                         System.IO.Path.GetFileNameWithoutExtension(PartitionDir).IndexOf(".") + 1)
                                });
                            }
                  
                        }
                    }
                    //Mining Structure
                    foreach (MiningStructure OLAPMiningStructure in OLAPDatabase.MiningStructures)
                    {
                        idx++;
                        string MiningStructureDir = DbObjectsDir.Where(x => x.StartsWith(CurrentDbDir + "\\" + OLAPMiningStructure.ID.ToString() + ".") && x.EndsWith(".dms")).DefaultIfEmpty("").First();
                        string MiningStructureXmlFile = DbObjectsFiles.Where(x => x.StartsWith(CurrentDbDir + "\\" + OLAPMiningStructure.ID.ToString() + ".") && x.EndsWith(".dms.xml")).DefaultIfEmpty("").First();
                        result.Add(new SSASObject
                        {
                            ID = idx,
                            ParentID = DbID,
                            ObjectID = OLAPMiningStructure.ID,
                            FolderModifiedDate = MiningStructureDir == "" ? dt : System.IO.Directory.GetLastWriteTime(MiningStructureDir),
                            XmlIncremetalID = System.IO.Path.GetFileNameWithoutExtension(
                                              System.IO.Path.GetFileNameWithoutExtension(MiningStructureXmlFile)).Substring(
                                              System.IO.Path.GetFileNameWithoutExtension(MiningStructureXmlFile).IndexOf(".") + 1),
                            Extension = ".ds",
                            FolderName = System.IO.Path.GetFileName(MiningStructureDir),
                            FolderPath = MiningStructureDir,
                            ObjectName = OLAPMiningStructure.Name,
                            Type = SSASObject.ObjectType.MiningStructure,
                            XMLFileName = System.IO.Path.GetFileName(MiningStructureXmlFile),
                            XMLFilePath = MiningStructureXmlFile,
                            XmlModifiedDate = MiningStructureXmlFile == "" ? dt : System.IO.File.GetLastWriteTime(MiningStructureXmlFile),
                            FolderIncremetalID = System.IO.Path.GetFileNameWithoutExtension(MiningStructureDir).Substring(
                                                 System.IO.Path.GetFileNameWithoutExtension(MiningStructureDir).IndexOf(".") + 1)
                        });
                    }
                    
                    
                    //Role
                    foreach (Role OLAPRole in OLAPDatabase.Roles)
                    {
                        idx++;
                        string RoleDir = DbObjectsDir.Where(x => x.StartsWith(CurrentDbDir + "\\" + OLAPRole.ID.ToString() + ".") && x.EndsWith(".dms")).DefaultIfEmpty("").First();
                        string RoleXmlFile = DbObjectsFiles.Where(x => x.StartsWith(CurrentDbDir + "\\" + OLAPRole.ID.ToString() + ".") && x.EndsWith(".dms.xml")).DefaultIfEmpty("").First();
                        result.Add(new SSASObject
                        {
                            ID = idx,
                            ParentID = DbID,
                            ObjectID = OLAPRole.ID,
                            FolderModifiedDate = RoleDir == "" ? dt : System.IO.Directory.GetLastWriteTime(RoleDir),
                            XmlIncremetalID = System.IO.Path.GetFileNameWithoutExtension(
                                              System.IO.Path.GetFileNameWithoutExtension(RoleXmlFile)).Substring(
                                              System.IO.Path.GetFileNameWithoutExtension(RoleXmlFile).IndexOf(".") + 1),
                            Extension = ".ds",
                            FolderName = System.IO.Path.GetFileName(RoleDir),
                            FolderPath = RoleDir,
                            ObjectName = OLAPRole.Name,
                            Type = SSASObject.ObjectType.Role,
                            XMLFileName = System.IO.Path.GetFileName(RoleXmlFile),
                            XMLFilePath = RoleXmlFile,
                            XmlModifiedDate = RoleXmlFile == "" ? dt : System.IO.File.GetLastWriteTime(RoleXmlFile),
                            FolderIncremetalID = System.IO.Path.GetFileNameWithoutExtension(RoleDir).Substring(
                                                 System.IO.Path.GetFileNameWithoutExtension(RoleDir).IndexOf(".") + 1)
                        });
                    }
                }
                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
