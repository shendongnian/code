    public string NewTitle(string OldTitle)
        {
            int HowManyWords = 3;
            string RetValue = "";
            string[] parts = OldTitle.Split(' ');
            for (int i = 0; i < parts.Length; i++)
            {
                if (i == 0)
                {
                    RetValue += parts[i];
                }
                else
                {
                    RetValue += " " + parts[i];
                }
                if (i >= (HowManyWords-1))
                {
                    break;
                }
            }
            return RetValue;
        }
