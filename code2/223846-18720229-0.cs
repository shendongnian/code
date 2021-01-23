            string file = "File to open";
            string text;
            Encoding encoding;
            string oldValue = "string to be replaced";
            string replacementValue = "New string";
            var attributes = File.GetAttributes(file);
            File.SetAttributes(file, attributes & ~FileAttributes.ReadOnly);
     
            using (StreamReader reader = new StreamReader(file, Encoding.Default))
            {
                text = reader.ReadToEnd();
                encoding = reader.CurrentEncoding;
                reader.Close();
            }
                         
            bool changedValue = false;
            if (text.Contains(oldValue))
            {
                text = text.Replace(oldValue, replacementValue);
                changedValue = true;
            }
            if (changedValue)
            {
                using (StreamWriter write = new StreamWriter(file, false, encoding))
                {
                    write.Write(text.ToString());
                    write.Close();
                }
                File.SetAttributes(file, attributes | FileAttributes.ReadOnly);
            }
