    public class Entity<T> where T : Entity<T>{}
    
    public class MyEntity : Entity<MyEntity>{}
...
    var mockValidator = new Mock<IValidator<MyEntity>>();
    var mockRepository = new Mock<IRepository<MyEntity>>();
    
    var id = Guid.NewGuid();
    var entity = new MyEntity();
    mockRepository.Setup(r => r.Get(id)).Returns(entity);
    mockValidator.Setup(v => v.ValidateAndThrow(entity));
    Assert.IsTrue(new ValidationService<MyEntity>(mockRepository.Object, mockValidator.Object).TryValidate(id));
    mockRepository.VerifyAll();
    mockValidator.VerifyAll();
