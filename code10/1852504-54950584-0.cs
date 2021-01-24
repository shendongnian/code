    public interface IRandomNumberGenerator
    {
        void NextBytes(byte[] buffer);
    }
    
    var randomImplementation = Substitute.For<IRandomNumberGenerator>();    
    randomImplementation.When(x => x.NextBytes(Arg.Any<byte[]>())).Do(x =>
    {
        var byteArray = x.Arg<byte[]>();
        byteArray [0] = 0x4d;
        byteArray [0] = 0x65;
        byteArray [0] = 0x64;
        byteArray [0] = 0x76;
    });
