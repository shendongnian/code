            string testData = "This is my fake data for matching this string";
            string searchPhrase = "thiS";
            string resultSet = "";
            for (int i = 0; i < testData.Length - searchPhrase.Length; i++)
            {
                if (searchPhrase.ToLower() == testData.Substring(i, searchPhrase.Length).ToLower())
                {
                    resultSet += "<span class='highlight'>" + testData.Substring(i, searchPhrase.Length) + "</span>";
                    i += searchPhrase.Length -1;
                }
                else
                {
                    resultSet += testData[i].ToString();
                }
            }
            Console.WriteLine(resultSet);
