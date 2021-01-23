        public bool ModifyFile(string filePath, List targetText, string replacementText)
        {
            if (!File.Exists(filePath)) return false;
            if (targetText == null || targetText.Count == 0) return false;
            if (string.IsNullOrEmpty(replacementText)) return false;
            string modifiedFileContent = string.Empty;
            bool hasContentChanged = false;
            Encoding sourceEndocing = null;
            //Read in the file content
            using (StreamReader reader = File.OpenText(filePath))
            {
                sourceEndocing = reader.CurrentEncoding;
                string file = reader.ReadToEnd();
                //Replace any target text with the replacement text
                foreach (string text in targetText)
                    modifiedFileContent = file.Replace(text, replacementText);
                if (!file.Equals(modifiedFileContent))
                    hasContentChanged = true;
            }
            //If we haven't modified the file, dont bother saving it
            if (!hasContentChanged) return false;
            //Write the modifications back to the file
            using (StreamWriter writer = new StreamWriter(filePath, false, sourceEndocing))
            {
                writer.Write(modifiedFileContent);
            }
            return true;
        }
