    var documentDto = new NctsDepartureNoDto();
    documentDto.IsDirty = true;
    documentDto.Id = 0;
    IDbContext context = MockRepository.GenerateMock<IDbRepository>();    context.Expect(x=>x.BeginTransaction()).Return(MockRepository.GenerateStub<ITransaction>());
    context.Expect(x=>x.CommitChanges());
