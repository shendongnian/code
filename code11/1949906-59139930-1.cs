        private static CancellationTokenSource TokenSource { get; set; }
        private static Int32 Counter { get; set; }
        [HttpPost("WorkHard")]
        public IActionResult WorkHard()
        {
            TokenSource = new CancellationTokenSource();
            _ = Task.Run(async () =>
              {
                  while (true)
                  {
                      TokenSource.Token.ThrowIfCancellationRequested();
                      await Task.Delay(500);
                      Counter++;
                  }
              }, TokenSource.Token);
            return Ok();
        }
        [HttpPost("CancelWorkHard")]
        public IActionResult CancelWorkHard()
        {
            TokenSource.Cancel();
            return Ok(Counter);
        }
