    public partial class StoredProcedures{
        [Microsoft.SqlServer.Server.SqlProcedure]
        public static void CKTransfrom(out string resultXML, string inputXML, string transformXSL){
        XslCompiledTransform proc = new XslCompiledTransform();
        using (StringReader sr = new StringReader(transformXSL)){
            using (XmlReader xr = XmlReader.Create(sr)){
                proc.Load(xr);
            }
        }
        using (StringReader sr = new StringReader(inputXML)){
            using (XmlReader xr = XmlReader.Create(sr)){
                using (StringWriter sw = new StringWriter()){
                    proc.Transform(xr, null, sw);
                    resultXML = sw.ToString();
    }}}}}
