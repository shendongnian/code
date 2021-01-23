            using (var browser = new IE(new Uri(HtmlTestBaseURI, "Test.htm")))
            {
                var details = browser.TableCells.Filter(Find.ByClass("detail"));
                var item = details.First( cell => cell.Link(Find.ByText("KEYWORD")).Exists);
                if (!item.Exists) return;
                var euro = item.Div(Find.ByClass("eur")).Text;
                var dollar = item.Div(Find.ByClass("usd")).Text;
            }
