    public class RunInterop
    {
        private AlphaShapeCg _alphaHandler;
        private DoubleCgList _alphaLevels;
        private FaceCgList _faceCgList;
        public RunInterop()
        {
            AlphaShapeCg faceCgList = new FaceCgList();
            DoubleCgList alphaLevels = new DoubleCgList();
            Interop_Init(ref _alphaHandler, ref faceCgList, ref alphaLevels);
            Interop_Run(ref _alphaHandler);
            _alphaLevels = alphaLevels;
            _faceCgList = faceCgList;
        }
    }
