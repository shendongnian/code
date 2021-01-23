            List<Rectangle[]> rectangleArr;
            var query = (from r in rectangleArr.Cast<Rectangle>()
                         group r by r into gr
                         select new { Count = gr.Count(), Value = gr.Key });
            foreach (var item in query)
            {
                Console.WriteLine("Item: {0}, Count: {1}", item.Value, item.Count);
            }
