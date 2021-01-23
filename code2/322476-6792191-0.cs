    var items = File.ReadAllLines(fileName)
                    .Select(line =>
                    {
                        var columns = line.Split('=', '@');
                        return new
                        {
                            ItemName = columns[0].Trim(),
                            Description = columns[1].Trim(),
                            MoreInfo = columns[2].Trim()
                        };
                    });
