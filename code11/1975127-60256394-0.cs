 private string ReturnMaskedName(string name)
        {
            string temporary = "";
            var newname = (name.Split(new string[] { "," }, StringSplitOptions.None)[1].Trim().Split(new String[] { " " }, StringSplitOptions.None));
            foreach (string allnames in newname)
            {
                temporary = temporary + " " + allnames[0].ToString() + new string('X', allnames.Length - 1);
            }
            return name.Split(new string[] { " " }, StringSplitOptions.None)[0] + " " + temporary;
        }
