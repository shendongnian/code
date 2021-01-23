    public static string[] StringSplitWrap(string sentence, int MaxLength)
    {
            List<string> parts = new List<string>();
            //string sentence = "Silver badges are awarded for longer term goals. Silver badges are uncommon.";
            string[] pieces = sentence.Split(' ');
            StringBuilder tempString = new StringBuilder("");
            foreach (var piece in pieces)
            {
                if (piece == "badges")
                {
                }
                if (piece.Length + tempString.Length + 1 > MaxLength)
                {
                    parts.Add(tempString.ToString());
                    tempString.Clear();
                }
                tempString.Append((tempString.Length == 0 ? "" : " ") + piece);
            }
            if (tempString.Length>0)
                parts.Add(tempString.ToString());
            return parts.ToArray();
    }
