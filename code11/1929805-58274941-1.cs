    CoreResponse response;
    public UserController(IOptions<SystemSettings> settings)
    {
        c = new DBConnect(settings);
        response = new CoreResponse();
        response.status = "fail";
        response.errors = new List<string>();
    }
    // Could also return bool if you want the caller to take a different
    // action if the validation fails.
    private void ValidateKey(string key)
    {
        chk = new KeyCheck();
        if (!chk.isValidKey(c, key)) {
            // Response already initialized in constructor
            response.errors.Add("Invalid Key")
        }
    }
    public CoreResponse EditUser(string key, [FromBody]User input) {
        ValidateKey(key);
    }
