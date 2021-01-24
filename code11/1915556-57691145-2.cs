    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Http;
    using System.IO;
    using System.Threading.Tasks;
    using System.Text;
    using System.Text.RegularExpressions;
    namespace CATS.Web.Shared.Infrastructure.Middleware
    {
    
        using CATS.Web.Shared.Repositories;
    
        public class HtmlMinificationMiddleware
        {
            private RequestDelegate _next;
            StatsRepository _stats;
            private HtmlMinificationOptions _minificationOptions;
            public HtmlMinificationMiddleware(RequestDelegate next, StatsRepository stats)
                : this(next, null, stats)
            {
            }
            public HtmlMinificationMiddleware(RequestDelegate next, HtmlMinificationOptions minificationOptions, StatsRepository stats)
            {
                _next = next;
                _minificationOptions = minificationOptions;
                _stats = stats;
            }
            public async Task Invoke(HttpContext context)
            {
                var stream = context.Response.Body;
                if (_minificationOptions != null)
                {
                    var filter = _minificationOptions.ExcludeFilter;
                    if (Regex.IsMatch(context.Request.Path, filter))
                    {
                        await _next(context);
                        return;
                    }
                }
                long size = 0;
                try
                {
                    using (var buffer = new MemoryStream())
                    {
                        context.Response.Body = buffer;
                        await _next(context);
                        var isHtml = context.Response.ContentType?.ToLower().Contains("text/html");
    
                        buffer.Seek(0, SeekOrigin.Begin);
                        using (var reader = new StreamReader(buffer))
                        {
                            string responseBody = await reader.ReadToEndAsync();
                            var backup = string.Copy(responseBody);
                            if (context.Response.StatusCode == 200 && isHtml.GetValueOrDefault())
                            {
                                try
                                {
                                    responseBody = Regex.Replace(responseBody, @">\s+<", "><", RegexOptions.Compiled | RegexOptions.Multiline);
                                    responseBody = Regex.Replace(responseBody, @"<!--(?!\s*(?:\[if [^\]]+]|<!|>))(?:(?!-->)(.|\n))*-->", "", RegexOptions.Compiled | RegexOptions.Multiline);
                                    responseBody = Regex.Replace(responseBody, @"\r\n?|\n", "", RegexOptions.Compiled | RegexOptions.Multiline);
                                    responseBody = Regex.Replace(responseBody, @"\s+", " ", RegexOptions.Compiled | RegexOptions.Multiline);
                                    if (string.IsNullOrWhiteSpace(responseBody))
                                        responseBody = backup;
                                } catch
                                {
                                    responseBody = backup;
                                }
                            }
                            var bytes = Encoding.UTF8.GetBytes(responseBody);
                            using (var memoryStream = new MemoryStream(bytes))
                            {
                                memoryStream.Seek(0, SeekOrigin.Begin);
                                await memoryStream.CopyToAsync(stream);
                            }
                            size = bytes.LongLength;
                            await _stats.UpdateRequestSize(context, size);
                        }
    
                    }
                }
                finally
                {
    
                    context.Response.Body = stream;
                }
    
            }
        }
    
    }
    public class HtmlMinificationOptions
    {
        public string ExcludeFilter { get; set; }
    }
