            foreach (var character in charArray)
            {
                var cat = char.GetUnicodeCategory(character);
                if (cat != UnicodeCategory.OtherLetter)
                {
                    continue;
                }
                isChineseTextPresent = true;
                break;
            }
