    using(DocX doc = DocX.Load("sample.docx"))
    {
         for (int i = 0; i < doc.Paragraphs.Count; i++ )
         {
              foreach (var item in doc.Paragraphs[i].Text.Split(new string[]{"\n"}
                        , StringSplitOptions.RemoveEmptyEntries))
              {
                    Console.WriteLine(item);
              }
         }
    }
