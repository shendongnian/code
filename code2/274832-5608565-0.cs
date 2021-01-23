                switch (title)
                {
                    case "Date":
                        HtmlNode date = valueRow.SelectSingleNode("//*[starts-with(@id, 'detail_row_seek')]/td");
                        Console.WriteLine("UPC=A:\t" + date.InnerText);
                        break;
                    case "News":
                        string News = valueRow.InnerText;
                        Console.WriteLine("News:\t" + News);
                        break;
                    default:
                        if (regexTime.Match(title))
                        {
                            string Time = valueRow.InnerText;
                            Console.WriteLine("Time:\t" + Time);
                        }
                        break;
                }
