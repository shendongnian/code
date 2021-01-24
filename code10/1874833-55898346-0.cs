    public interface IProfilePhotoContentRequest : IBaseRequest
    {
        /// <summary>Gets the stream.</summary>
        /// <returns>The stream.</returns>
        Task<Stream> GetAsync();
    
        /// <summary>Gets the stream.</summary>
        /// <param name="cancellationToken">The <see cref="T:System.Threading.CancellationToken" /> for the request.</param>
        /// <param name="completionOption">The <see cref="T:System.Net.Http.HttpCompletionOption" /> to pass to the <see cref="T:Microsoft.Graph.IHttpProvider" /> on send.</param>
        /// <returns>The stream.</returns>
        Task<Stream> GetAsync(
          CancellationToken cancellationToken,
          HttpCompletionOption completionOption = HttpCompletionOption.ResponseContentRead);
    
        //...
    }
