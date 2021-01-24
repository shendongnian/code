    public class AccountRegisterDTO
    {
        [Required] // This property is obligatory, it MUST exist in JSON
        [MinLength(6, ErrorMessage = "Username must be at least 6 characters long")] // Must be minimum 6 characters long
        [RegularExpression(@"^\d*[a-zA-Z][a-zA-Z\d]*$", ErrorMessage = "Username can contain only letters and numbers")] // Must Match the RegEx
        public string Username { get; set; }
        [Required]
        [MinLength(8, ErrorMessage = "Password must be at least 8 characters long")]
        [RegularExpression(@"^(?=.*[A-Z])(?=.*[a-z])(?=.*[\d])((?=.*[^\w\s])|(?=.*[ ])).*$", ErrorMessage = "Password don't meet passwords policy")]
        public string Password { get; set; }
        [Required]
        [EmailAddress(ErrorMessage = "Email address is not valid")] // Automatically validate if e-mail address is correct
        public string EmailAddress { get; set; }
    }
Usage is very simple, it looks like this:
        [AllowAnonymous]
        [HttpPost("Register")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> Register([FromBody] AccountRegisterDTO registerAccount)
        {
            // Code will not even reach this point if JSON is not valid according to DataAnnotations Attributes
        }
For passed arguments:
[![enter image description here][1]][1]
Returned errors looks like this:
[![enter image description here][2]][2]
  [1]: https://i.stack.imgur.com/OMxBB.png
  [2]: https://i.stack.imgur.com/OslM6.png
