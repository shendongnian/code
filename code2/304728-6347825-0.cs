    [Then(@"the result should be")]
        public void ThenTheResultShouldBe(Table table)
        {
            foreach (var row in table.Rows)
            {
                var numberValue = row["Numbers"]; // the name of the column specified
            }
        }
