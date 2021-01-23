    // Iterate all rows in the first table
    HtmlNodeCollection rows = tables[0].SelectNodes(".//tr");
    for (int i = 0; i < rows.Count; ++i)
    {
        // Iterate all columns in this row
        HtmlNodeCollection cols = rows[i].SelectNodes(".//td");
        for (int j = 0; j < cols.Count; ++j)
        {
            var images = cols[j].SelectNodes("img");
            if(images!=null)
                foreach (var image in images)
                {
                    if(image.Attributes["alt"]!=null)
                        Console.WriteLine(image.Attributes["alt"].Value);
                }
            // Get the value of the column and print it
            string value = cols[j].InnerText;
            Console.WriteLine(value);
        }
    }
