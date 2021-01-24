namespace Microsoft.AspNetCore.DataProtection
{
    /// <summary>
    /// An interface that can provide data protection services.
    /// </summary>
    public interface IDataProtector : IDataProtectionProvider
    {
        /// <summary>
        /// Cryptographically protects a piece of plaintext data.
        /// </summary>
        /// <param name="plaintext">The plaintext data to protect.</param>
        /// <returns>The protected form of the plaintext data.</returns>
        byte[] Protect(byte[] plaintext);
        /// <summary>
        /// Cryptographically unprotects a piece of protected data.
        /// </summary>
        /// <param name="protectedData">The protected data to unprotect.</param>
        /// <returns>The plaintext form of the protected data.</returns>
        /// <exception cref="System.Security.Cryptography.CryptographicException">
        /// Thrown if the protected data is invalid or malformed.
        /// </exception>
        byte[] Unprotect(byte[] protectedData);
    }
}
namespace Microsoft.AspNetCore.DataProtection
{
    /// <summary>
    /// An interface that can be used to create <see cref="IDataProtector"/> instances.
    /// </summary>
    public interface IDataProtectionProvider
    {
        /// <summary>
        /// Creates an <see cref="IDataProtector"/> given a purpose.
        /// </summary>
        /// <param name="purpose">
        /// The purpose to be assigned to the newly-created <see cref="IDataProtector"/>.
        /// </param>
        /// <returns>An IDataProtector tied to the provided purpose.</returns>
        /// <remarks>
        /// The <paramref name="purpose"/> parameter must be unique for the intended use case; two
        /// different <see cref="IDataProtector"/> instances created with two different <paramref name="purpose"/>
        /// values will not be able to decipher each other's payloads. The <paramref name="purpose"/> parameter
        /// value is not intended to be kept secret.
        /// </remarks>
        IDataProtector CreateProtector(string purpose);
    }
}
They are both abstractions of some implementation that the WS-Federation is implementating (one or the other or both) or that it is using (Expecting it from some kind of DI container or constructor). In any case, you won't get it to work without it.
The way to set this up is to also install the nuget package [from here][4]
  [1]: https://github.com/dotnet/aspnetcore/tree/e276c8174b8bfdeb70efceafa81c75f8badbc8db/src/DataProtection/Abstractions/src
  [2]: https://github.com/dotnet/aspnetcore/blob/e276c8174b8bfdeb70efceafa81c75f8badbc8db/src/DataProtection/Abstractions/src/IDataProtector.cs
  [3]: https://github.com/dotnet/aspnetcore/blob/e276c8174b8bfdeb70efceafa81c75f8badbc8db/src/DataProtection/Abstractions/src/IDataProtectionProvider.cs
  [4]: https://www.nuget.org/packages/Microsoft.AspNetCore.DataProtection.Abstractions/
