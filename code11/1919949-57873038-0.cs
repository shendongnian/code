        public static IWebElement LoggedUntil(this WebDriverWait wait, Func<IWebDriver, IWebElement> condition)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            try
            {
                return wait.Until(condition);
            }
            finally
            {
                watch.Stop();
                var elapsedSeconds = watch.Elapsed.TotalSeconds;
                Console.WriteLine($"Wait took: {elapsedSeconds} Seconds");
            }
        }
