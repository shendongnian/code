    [HttpPost]
    public ActionResult Index([Deserialize(SerializationMode.EncryptedAndSigned)] RegistrationViewModel registrationModel)
    {
        ...
    }
