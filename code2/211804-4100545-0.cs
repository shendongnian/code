    var agg = list.Aggregate(
        new List<List<Line>>(),
        (groupedLines, line) => {
            if (!groupedLines.Any()) {
                groupedLines.Add(new List<Line>() { line });
            }
            else {
                List<Line> last = groupedLines.Last();
                if (last.First().LineId == line.LineId) {
                    last.Add(line);
                }
                else {
                    List<Line> newGroup = new List<Line>();
                    newGroup.Add(line);
                    groupedLines.Add(newGroup);
                }
            }
            return groupedLines;
        }
    );
           
