        [HttpPost("foo/{bar}")]
        public async Task<IActionResult> Foo(string bar)
        {
            var user = User.FindFirst(ClaimTypes.Name).Value;//use whatever kind of claim type you want.
           var db = this.dbChooser.GetDbForUser(user);
            return this.ReturnIfOk(await DoSomeWork(db));
        }
