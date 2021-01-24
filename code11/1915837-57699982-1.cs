    public static string GetRandomParagraph(string filePath)
        {
            if (File.Exists(filePath))
            {
                string text = File.ReadAllText(filePath);
                string[] paragraphs = text.Split(new string[] { "\n\n" }, StringSplitOptions.None);
                string [] paragraph = paragraphs[new Random().Next(0, paragraphs.Length)].Split('\n');
                //Added a for loop to build the string out of all the characters in the 'paragraph' array index.
                string pReturn = "";
                for (int a = 0; a < paragraph.Length; a++)
                {
                    //Loop through and consecutively append each character of mapped array index to a return string 'pReturn'
                    pReturn = pReturn + paragraph[a].ToString();
                }
                return pReturn;
            }
            else
                throw new FileNotFoundException("The file was not found", filePath);
        }
