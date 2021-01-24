    using DocumentFormat.OpenXml.Packaging;
    using DocumentFormat.OpenXml.Wordprocessing;
    using System.Linq;
    namespace ChangeDocVariable
    {
        class Program
        {
            /// <summary>
            /// Retrieves a document variable by its name
            /// </summary>
            /// <param name="name">The name of the document variable (case sensitive)</param>
            /// <param name="document">The wordprocessing document</param>
            /// <returns>The document variable if found, other wise it returns null</returns>
            public static DocumentVariable GetVariableByName(string name, WordprocessingDocument document)
            {
                // Get the document settings part
                DocumentSettingsPart documentSettings = document.MainDocumentPart.DocumentSettingsPart;
                // Get the settings element
                Settings settings = documentSettings.Settings;
                // Get the DocumentVariables element
                DocumentVariables variables = settings.Elements<DocumentVariables>().FirstOrDefault();
                // check if the variables are not null
                if(variables != null)
                {
                    return variables.Elements<DocumentVariable>().Where(v => v.Name == name)
                        .FirstOrDefault();
                }
                return null;
            }
            /// <summary>
            /// Sets the value of a document variable
            /// </summary>
            /// <param name="variable">The variable</param>
            /// <param name="value">The value</param>
            public static void SetDocumentVariableValue(DocumentVariable variable, string value)
            {
                variable.Val = value;
            }
            static void Main(string[] args)
            {
                string path = @"This should be the path to your document";
                using(WordprocessingDocument document = WordprocessingDocument.Open(path, true))
                {
                    DocumentVariable variable = GetVariableByName("TestVariable", document);
                    if(variable != null)
                        SetDocumentVariableValue(variable, "New Value");
                    // Or access the value directly
                    // variable.Val = "New Value";
                    document.Save();
                }
            }
        }
    }
