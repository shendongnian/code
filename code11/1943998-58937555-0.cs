        private static Phrase CreateSimpleHtmlParagraph(String text)
        {
            var p = new Phrase();
            var mh = new MyElementHandler();
            using (TextReader sr = new StringReader("<html><body><p>" + text + "</p></body></html>"))
            {
                XMLWorkerHelper.GetInstance().ParseXHtml(mh, sr);
            }
            foreach (var element in mh.elements)
            {
                foreach (var chunk in element.Chunks)
                {
                    p.Add(chunk);
                }
            }
            return p;
        }
    *(The helper class `MyElementHandler` is shown in the referenced answer.)*
