    [WebGet(ResponseFormat = WebMessageFormat.Json)]
        protected override IEnumerable<KeyValuePair<string, SampleItem>> OnGetItems()
        {
            // TODO: Change the sample implementation here
            if (items.Count == 0)
            {
                items.Add("A", new SampleItem() { Value = "A" });
                items.Add("B", new SampleItem() { Value = "B" });
                items.Add("C", new SampleItem() { Value = "C" });
            }
            return this.items;
        }
