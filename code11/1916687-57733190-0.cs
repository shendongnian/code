    using System;
    using System.Collections.Generic;
    using iText.Forms;
    using iText.Forms.Fields;
    using iText.Kernel.Pdf;
    namespace ConsoleApplication1 {
        class Class1 {      
            public string pdfthree(string pdfPath) {            
                PdfReader reader = new PdfReader(pdfPath);
                PdfDocument document = new PdfDocument(reader);
                PdfAcroForm acroForm = PdfAcroForm.GetAcroForm(document, false);
                IDictionary<string, PdfFormField> Map = new Dictionary<string, PdfFormField>();
                Map = acroForm.GetFormFields();
                acroForm.GetField("Name");
                string output = "";
                foreach (String fldName in Map.Keys) {
                    output += fldName + ": " + Map[fldName].GetValueAsString() + "\n";
                }
                System.IO.File.WriteAllText(pdfPath, output);
                document.Close();
                reader.Close();
                return output;
            }
        }
    }
