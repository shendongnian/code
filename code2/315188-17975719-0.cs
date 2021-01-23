        public List<Tuple<string,string>> GetAllMacrosInExcelFile(string fileName) {
            List<Tuple<string,string>> listOfMacros = new List<Tuple<string,string>>();
            var excel = new Excel.Application();
            var workbook = excel.Workbooks.Open(fileName, false, true, Type.Missing, Type.Missing, Type.Missing, true, Type.Missing, Type.Missing, false, false, Type.Missing, false, true, Type.Missing);
            var project = workbook.VBProject;
            var projectName = project.Name;
            var procedureType = Microsoft.Vbe.Interop.vbext_ProcKind.vbext_pk_Proc;
            foreach (var component in project.VBComponents) {
                VBA.VBComponent vbComponent = component as VBA.VBComponent;
                if (vbComponent != null) {
                    string componentName = vbComponent.Name;
                    var componentCode = vbComponent.CodeModule;
                    int componentCodeLines = componentCode.CountOfLines;
                    int line = 1;
                    while (line < componentCodeLines) {
                        string procedureName = componentCode.get_ProcOfLine(line, out procedureType);
                        if (procedureName != string.Empty) {
                            int procedureLines = componentCode.get_ProcCountLines(procedureName, procedureType);
                            int procedureStartLine = componentCode.get_ProcStartLine(procedureName, procedureType);
                            var allCodeLines = componentCode.get_Lines(procedureStartLine, procedureLines);
                       
                            Regex regex = new Regex("Macro\r\n' (.*?)\r\n'\r\n\r\n'");
                            var v = regex.Match(allCodeLines);
                            string comments = v.Groups[1].ToString();
                            if (comments.IsEmpty()) { comments = "No comment is written for this Macro"; }
    
                            line += procedureLines - 1;
                            listOfMacros.Add(procedureName.Tuple(comments));
                        } 
                        line++;
                    }
                }
            }
            excel.Quit();
            return listOfMacros;
        }
