    private async Task<HttpResponseMessage> SetAuthHeaderAndSendAsync(HttpRequestMessage request, CancellationToken cancellationToken, bool forceTokenRefresh)
    {      
      var requestContent = await request.Content.ReadAsStringAsync();
      request.Headers.Add("X-OriginalHash", new Md5PasswordHasher().Hash(requestContent)); 
      return await base.SendAsync(request, cancellationToken).ConfigureAwait(false);  
    }
    public class Md5PasswordHasher : IPasswordHasher
    {
    public string Hash(string password)
    {    
      return CalculateMD5Hash(password);
    }
    
    private string CalculateMD5Hash(string input)
    {
      MD5 md5 = System.Security.Cryptography.MD5.Create();
      byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
      byte[] hash = md5.ComputeHash(inputBytes);
    
      StringBuilder sb = new StringBuilder();
      for (int i = 0; i < hash.Length; i++)
    	sb.Append(hash[i].ToString("x2"));
    
      string result = sb.ToString();
      return result;
    }
    }
