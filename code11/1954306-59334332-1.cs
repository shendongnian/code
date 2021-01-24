    public class PdfService
    {
        Dictionary<string, Task> _workMap = new Dictionary<string, Task>();
    
        public string StartGeneration(PdfModel model)
        {
            var pdfBuilder = new PdfBuilder();
            var task = pdfBuildr.BuildAsync(model);
            var ticket = Guid.NewGuid().ToString("N");
            _workMap[ticket] = task;
            return ticket;
        }
    
        public bool TryGet(string ticket, out PdfDocument doc)
        {
            var task = _workMap[ticket);
            if (task.IsCompleted)
            {
                doc = task.Result;
                return true;
            }
    
            return false;
        }
    }
