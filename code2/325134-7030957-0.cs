                // Reads the lines in the file to format.
                var fileReader = File.OpenText(filePath + "\\Calculating X,Y File.txt");
                // Creates a list for the lines to be stored in.
                var fileList = new List<string>();
                // Adds each line in the file to the list.
                var fileLines = "";
                while ((fileLines = fileReader.ReadLine()) != null)
                    fileList.Add(fileLines);
                // Creates new lists to hold certain matches for each list.
                var xyResult = new List<string>();
                var xResult = new List<string>();
                var yResult = new List<string>();
                // Iterate over each line in the file and extract the x and y values
                fileList.ForEach(line =>
                {
                    Match xyMatch = Regex.Match(line, @"(?<x>-?\d+\.\d+)\s+(?<y>-?\d+\.\d+)");
                    if (xyMatch.Success)
                    {
                        // Grab the x and y values from the regular expression match
                        String xValue = xyMatch.Groups["x"].Value;
                        String yValue = xyMatch.Groups["y"].Value;
                        // Add these two values, separated by a space, to the "xyResult" list.
                        xyResult.Add(String.Join(" ", new[] { xValue, yValue }));
                        // Add the results to the lists.
                        xResult.Add(xValue);
                        yResult.Add(yValue);
                        // Store the old X and Y values.
                        oldXRichTextBox.AppendText(xValue + Environment.NewLine);
                        oldYRichTextBox.AppendText(yValue + Environment.NewLine);
                        try
                        {
                            // Calculate the X & Y values (including the x & y displacements)
                            double doubleX = double.Parse(xValue);
                            double doubleXValue = double.Parse(xDisplacementTextBox.Text);
                            StringBuilder sbX = new StringBuilder();
                            sbX.AppendLine((doubleXValue - doubleX).ToString());
                            double doubleY = double.Parse(yValue);
                            double doubleYValue = double.Parse(yDisplacementTextBox.Text);
                            StringBuilder sbY = new StringBuilder();
                            sbY.AppendLine((doubleY + doubleYValue).ToString());
                            calculateXRichTextBox.AppendText(sbX + "");
                            calculateYRichTextBox.AppendText(sbY + "");
                            // Removes the blank lines.
                            calculateXRichTextBox.Text = Regex.Replace(calculateXRichTextBox.Text, @"^\s*$(\n|\r|\r\n)", "", RegexOptions.Multiline);
                            calculateYRichTextBox.Text = Regex.Replace(calculateYRichTextBox.Text, @"^\s*$(\n|\r|\r\n)", "", RegexOptions.Multiline);
                        }
