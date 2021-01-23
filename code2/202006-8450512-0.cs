        static AcadApplication ACAD
        {
            get
            {
                return
                    Autodesk.AutoCAD.ApplicationServices.Application.AcadApplication as AcadApplication;
            }
        }
        [CommandMethod("tlo")]
        public static void TestLayerOff()
        {
            foreach (AcadEntity ent in ACAD.ActiveDocument.ModelSpace)
            {
                //... get xData from the entity.
                object xdata, xdataType;
                ent.GetXData("MyRegisteredAppName", out xdataType, out xdata);
                //... read and spit out the xdata to the command line to see what we got
            }
        }
