    class Salida
    {
        string _gdbName;
        ShapefileManage _shpManageOutput;
        IFeatureClass _outpuFc;
        //ISpatialReference spatialReference;
        
        public Salida(ShapefileManage shpManageOutput, ISpatialReference spatialReference, string gdbName)
        {
            this._gdbName = gdbName;
            this._shpManageOutput = shpManageOutput;
            crearCapaSalida(spatialReference, esriGeometryType.esriGeometryPoint);
        }
