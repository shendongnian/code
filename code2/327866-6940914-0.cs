    threads[i] = new Thread(() => {
        try {
            for (var j = 0; j < 10; j++) {
                // Send the request
                var request = Http.WebRequest("http://localhost/SomePage");
                var document = new HtmlDocument();
                document.LoadHtml(request.Data);
                // Get the required info
                var title = document.DocumentNode.SelectSingleNode("//title").InnerText.Trim();
                // Test if the info is valid
                if (title != "Some Page") {
                    isValid = false;
                    break;
                }
            }
        }
        catch (Exception ex) {
            Trace.WriteLine(ex);
        }
    });
