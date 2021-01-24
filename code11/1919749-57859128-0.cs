		public class UserRequest {
			public string Name { get; set; } //you can also remove this
			public string Email { get; set; }
			public string Password { get; set; }
		}
		[AllowAnonymous]
		[HttpPost("[action]")]
		public IActionResult Authenticate([FromBody] UserRequest operatorParam) {
			var user = _userService.Authenticate(operatorParam.Email, operatorParam.Password);
			if (user == null) {
				return BadRequest(new {message = "Email or password is incorrect"});
			}
			return Ok(user);
		}
