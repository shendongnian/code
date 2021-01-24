    public class InMemoryCrud : ICrud
    {
        public List<Model> Models { get; set; } = new List<Model>();
        public Task<IEnumerable<Model>> GetAllAsync() => return Task.FromResult(Models);        
        public Task AddAsync(Model model)
        {
            Models.Add(model);
            return Task.CompletedTask;
        }
    }
    public async Task Add_Model() 
    {
        var fakeCrud = new InMemoryCrud();
        var service = new Service(fakeCrud);
        var newModel = new Model { Id = 3 };
        await service.AddAsync(newModel);
        var actualModels = await fakeCrud.GetAllAsync();
        var expected = new[]
        {
            new Model { Id = 3 }
        }
        actualModels.Should().BeEquivalentTo(expected); // Pass
    }
