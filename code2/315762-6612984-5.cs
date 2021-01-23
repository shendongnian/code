    var page = document.Element("PrintJob")
                       .Element("Page");
    var boxes = page.Elements("Box")
                    .Select(x => (string)x)
                    .ToList();
    var texts = page.Elements("Text")
                    .Select(x => (string)x)
                    .ToList();
    foreach (var box in boxes)
        Console.WriteLine("Box: " + box);
    foreach (var text in texts)
        Console.WriteLine("Text: " + text);
