    var Dictionary1 = new Dictionary<string, int>();
    foreach (var item in records) {
                var tValue = new Tuple<string, string>(item.Id, item.details.DetailsId).ToString();
                if (!Dictionary1 .ContainsKey(tValue)) {
                    Dictionary1 .Add(tValue, 1);
                } else {
                    Dictionary1 .TryGetValue(tValue, out int count);
                    Dictionary1 .Remove(tValue);
                    Dictionary1 .Add(tValue, count + 1);
                }
            }
