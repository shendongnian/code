     IEnumerable<JToken> AllTokens(JObject obj)
            {
                var toSearch = new Stack<JToken>(obj.Children());
                while (toSearch.Count > 0)
                {
                    var inspected = toSearch.Pop();
                    yield return inspected;
                    foreach (var child in inspected)
                    {
                        toSearch.Push(child);
                    }
                }
            }
