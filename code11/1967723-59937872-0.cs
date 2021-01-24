    public void PrintInfoList(IEnumerable<ObjectInformation> list)
        {
            var result = string.Join("\n", list.Select(item => GetPrintedFormat(item)));
            Console.WriteLine(result);
        }
        public string GetPrintedFormat(ObjectInformation info)
        {
            string printedFormat = string.Empty;
            printedFormat = $"Fullname of {info.FriendlyName} - {info.FullName}";
            if (info.Children != null && info.Children.Any())
            {
                childCount++;
                _formatter = $"\n{string.Empty.PadRight(childCount, '\t')}";
                printedFormat += $"{_formatter}{string.Join(_formatter, info.Children.Select(child => GetPrintedFormat(child)))}";
            }
            else
                if (childCount > 0) childCount--;
            return printedFormat;
        }
