                var items = new System.Collections.Generic.List<AdaptiveElement>();
                for (int i = 0; i < whatever.count; i++)
                {
                    items.Add(new AdaptiveTextBlock()
                    {
                        Text = $"Item {i}",
                    });
                }
                card.Body.Add(
                    new AdaptiveContainer()
                    {
                        Items = items
                    }
                );
