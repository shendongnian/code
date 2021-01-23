            var button1ClickCount = 0;
            var button1Clicks = Observable
                .FromEventPattern(
                    h => button1.Click += h,
                    h => button1.Click -= h);
            var button1ClickCounts =
                from c in button1Clicks
                select ++button1ClickCount;
            var button1ClickMessages =
                from cc in button1ClickCounts
                let f = "You clicked the button {0} time{1}"
                select String.Format(f, cc, cc == 1 ? "" : "s");
