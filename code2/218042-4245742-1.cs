        protected List GetMultipleSeries(FrontModule module)
        {
            List listSeries = new List();
            Series seriesActual = new Series(module.Title);
            Series seriesBudgetted = new Series(module.Title);
            foreach (var keyPair in module.DictionaryValues)
            {
                string sFieldTitle = keyPair.Value.Text;
                Element element = new Element(sFieldTitle, keyPair.Value.Value);
                element.Color = Charter.GetColor(keyPair.Value.ColorIndex);
                // Is is actual or budgetted
                if (keyPair.Value.IsActual)
                    seriesActual.Elements.Add(element);
                else
                    seriesBudgetted.Elements.Add(element);
                string sToolTip = string.Format
                    ("{0}: {1:N0}"
                    , keyPair.Value.Tooltip
                    , keyPair.Value.Value);
                element.ToolTip = sToolTip;
                if (!string.IsNullOrEmpty(keyPair.Value.LinkUrl))
                {
                    element.URL = Page.ResolveUrl(keyPair.Value.LinkUrl);
                }
                ChartTooltip += string.Concat(sToolTip, ", ");
            }
            listSeries.Add(seriesActual);
            listSeries.Add(seriesBudgetted);
            ChartTooltip += "\n";
            return listSeries;
        }
