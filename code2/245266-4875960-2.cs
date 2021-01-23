        [Test]
        public void Should_be_better_readable_when_modeled_as_control()
        {
            using (var browser = new IE(new Uri(HtmlTestBaseURI, "Test.htm")))
            {
                var item = browser.Control<Item>(itm => itm.Title == "KEYWORD");
                // OR
                // var item = browser.Controls<Item>().First(itm => itm.Title == "KEYWORD");
                if (!item.Exists) return;
                var euro = item.GetPriceFor("eur");
                var dollar = item.GetPriceFor("usd");
            }
        }
        public class Item : Control<Table>
        {
            public override Constraints.Constraint ElementConstraint
            {
                get { return Find.ByClass(clss => clss != null && clss.Contains("item")); }
            }
            public string Title
            {
                get { return Element.Div(Find.ByClass("title")).Text.Trim(); }
            }
    
            public string Url
            {
                get { return Element.Div(Find.ByClass("title")).Link(Find.First()).Url; }
            }
            public string GetPriceFor(string currency)
            {
                return Element.Div(Find.ByClass("price")).Div(Find.ByClass(currency)).Text;
            }
        }
