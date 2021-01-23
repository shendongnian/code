    switch (title)
            {
                case "Date":
                    HtmlNode date = valueRow.SelectSingleNode("//*[starts-with(@id, 'detail_row_seek')]/td");
                    Console.WriteLine("UPC=A:\t" + date.InnerText);
                    break;
                case "":
                    string Time = valueRow.InnerText;
                    Console.WriteLine("Time:\t" + Time);
                    break;
                case "News":
                    string Time = valueRow.InnerText;
                    Console.WriteLine("News:\t" + News);
                    break;
                default:
                    // put special time condition check logic here.
            }
