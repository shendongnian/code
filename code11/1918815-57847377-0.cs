    var provider = Substitute.For<IProvider>();
    provider.InitMethod(Arg.Any<Info>(), "ABC").Returns(
        o => {
            validProvidersDto.ExportFolder = o.Arg<Info>().Name;
            return validProvidersDto;
        });
