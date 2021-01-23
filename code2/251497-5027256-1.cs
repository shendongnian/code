    public class MWCropperDataType : umbraco.cms.businesslogic.datatype.BaseDataType, umbraco.interfaces.IDataType
        {
            private umbraco.interfaces.IDataEditor _Editor;
            private umbraco.interfaces.IData _baseData;
            private MWCropperPrevalueEditor _prevalueeditor;
    
            public override umbraco.interfaces.IDataEditor DataEditor
            {
                get
                {
                    if (_Editor == null)
                        _Editor = new MWCropperDataEditor(Data, ((MWCropperPrevalueEditor)PrevalueEditor).Configuration);
                    return _Editor;
                }
            }
    
            public override umbraco.interfaces.IData Data
            {
                get
                {
                    if (_baseData == null)
                        _baseData = new umbraco.cms.businesslogic.datatype.DefaultData(this);
                    return _baseData;
                }
            }
            public override Guid Id
            {
                get { return new Guid("71518B4E-B1A5-11DD-A22C-8AAA56D89593"); }
            }
    
            public override string DataTypeName
            {
                get { return "MWCropper"; }
            }
    
            public override umbraco.interfaces.IDataPrevalue PrevalueEditor
            {
                get
                {
                    if (_prevalueeditor == null)
                        _prevalueeditor = new MWCropperPrevalueEditor(this);
                    return _prevalueeditor;
                }
            }
        }
