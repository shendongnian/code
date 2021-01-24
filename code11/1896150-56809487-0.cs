    using Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Http;
    using System;
    using System.Buffers;
    using System.Collections.Generic;
    using System.Text;
    
    public class ExampleUsage 
    {
    	public static void Main(string[] args)
        {
    		string requestString =
    		@"POST /resource/?query_id=0 HTTP/1.1
    		Host: example.com
    		User-Agent: custom
    		Accept: */*
    		Connection: close
    		Content-Length: 20
    		Content-Type: application/json
    
    		{""key1"":1, ""key2"":2}";
    		
    		var headerResult = Parser.Parse(requestString);
    	}
    }
    
    public class Parser : IHttpHeadersHandler
    {
    	private Dictionary<string, string> result = null;
    
    	public Dictionary<string, string> Parse(string requestString)
    	{
    		result = new Dictionary<string, string>();	
    		
    		byte[] requestRaw = Encoding.UTF8.GetBytes(requestString);
            ReadOnlySequence<byte> buffer = new ReadOnlySequence<byte>(requestRaw);
            HttpParser<Program> parser = new HttpParser<Program>();
    
            parser.ParseRequestLine(this, buffer, out var consumed, out var examined);
            buffer = buffer.Slice(consumed);
    
            parser.ParseHeaders(this, buffer, out consumed, out examined, out var b);
            buffer = buffer.Slice(consumed);
    	}
    	
    	public void OnHeader(Span<byte> name, Span<byte> value)
        {
            result.Add(Encoding.UTF8.GetString(name), Encoding.UTF8.GetString(value));
        }
    }
     
