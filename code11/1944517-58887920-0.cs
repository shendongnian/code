     PageIteratorLevel myLevel = PageIteratorLevel.Word;
            TesseractEngine engine = new TesseractEngine("./tessdata", "eng");
            var page = engine.Process(bitmap, PageSegMode.Auto);
            using (var iter = page.GetIterator())
            {
                iter.Begin();
                do
                {
                    if (iter.TryGetBoundingBox(myLevel, out var rect))
                    {
                        var curText = iter.GetText(myLevel);
                        if (curText == "awesome") //Here is your text
                        {
                            //Get rect.X1, rect.Y1, 
                        }
                    }
                } while (iter.Next(myLevel));
            }
