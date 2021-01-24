                   //Declare a 2nd TABLE class(This will get you second table of docx)
                    Table table2 = body.Elements<Table>().ElementAt(1);
                    //Access first row
                    row = table2.Elements<TableRow>().ElementAt(0);
                    //Accessing 2nd cell of that row
                    cell = row.Elements<TableCell>().ElementAt(1);
                    p = cell.Elements<Paragraph>().First();
                    r = p.Elements<Run>().First();
                    text1 = r.Elements<Text>().First();
                    //Replacing text in that CELL
                    text1.Text = text1.Text.Replace("xVal2x", "Item2");
