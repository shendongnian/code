            if (Surname.Contains("'"))
            {
               String[] Names = Surname.Split('\'').ToArray();
               Surname = textInfo.ToTitleCase(Names[0].ToString());
               Surname += "''";
               Surname += textInfo.ToTitleCase(Names[1].ToString());
            }
