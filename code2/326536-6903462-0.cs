    var orgService = new Mock<IOrganizationService>();
    var idResults = new ParameterCollection
    {
       {"Id", Guid.NewGuid()}
    };
    orgService.Setup(s => s.Execute(It.IsAny<SendEmailFromTemplateRequest>()))
                           .Returns(new SendEmailFromTemplateResponse
    {
       Results = idResults,
       ResponseName = "SendEmailFromTemplate"
    });
