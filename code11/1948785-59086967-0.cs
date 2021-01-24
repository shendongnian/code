            cell.Value2 = string.Join("", myTexts);
            var startIndex = 1;
            for (int i = 0; i < myTexts.Count; i++)
            {
                if (i % 2 == 0)
                {
                    cell.Characters[startIndex, myTexts[i].Length].Font.Color = Color.Green;
                }
                else
                {
                    cell.Characters[startIndex, myTexts[i].Length].Font.Color = Color.Red;
                }
                startIndex += myTexts[i].Length;
            }
