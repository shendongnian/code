            var groups = userInfoList
                .GroupBy(n => n.metric)
                .Select(n => new
                {
                    MetricName = n.Key,
                    MetricCount = n.Count()
                }
                )
                .OrderBy(n => n.MetricName);
