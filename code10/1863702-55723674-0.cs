        /// <summary>
        /// Retrieves a document variable by its name
        /// </summary>
        /// <param name="name">The name of the document variable (case sensitive)</param>
        /// <param name="document">The wordprocessing document</param>
        /// <returns>The document variable if found, other wise it returns null</returns>
        public DocumentVariable GetVariableByName(string name, WordprocessingDocument document)
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
