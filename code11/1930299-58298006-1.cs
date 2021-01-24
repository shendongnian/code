    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Http;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    
    using System.IO;
    using System.Text;
    using System.Net.Http;
    using System.Net.Http.Headers;
    
    namespace <your name space here>
    {
        public class Startup
        {
            private IConfiguration configuration;
    
            public Startup(IConfiguration configuration)
            {
                this.configuration = configuration;
            }
    
            public IConfiguration Configuration { get; }
    
            // This method gets called by the runtime. Use this method to add services to the container.
            public void ConfigureServices(IServiceCollection services)
            {
                services.AddRazorPages();
            }
    
            // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
            // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
            public void Configure(IApplicationBuilder app, Microsoft.AspNetCore.Hosting.IHostingEnvironment env)
            {
                // TODO: Change this to your image's path on your site.
                string imagePath = @"images/face1.jpg";
    
                // Enable static files such as image files.
                app.UseStaticFiles();
    
                string faceApiKey = this.configuration["FaceAPI_ServiceKey"];
                string faceApiEndPoint = this.configuration["FaceAPI_ServiceEndPoint"];
    
                HttpClient client = new HttpClient();
    
                // Request headers.
                client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", faceApiKey);
    
                // Request parameters. A third optional parameter is "details".
                string requestParameters = "returnFaceId=true&returnFaceLandmarks=false&returnFaceAttributes=age,gender,headPose,smile,facialHair,glasses,emotion,hair,makeup,occlusion,accessories,blur,exposure,noise";
    
                // Assemble the URI for the REST API Call.
                string uri = faceApiEndPoint + "/detect?" + requestParameters;
    
                // Request body. Posts an image you've added to your site's images folder.
                var fileInfo = env.WebRootFileProvider.GetFileInfo(imagePath);
                var byteData = GetImageAsByteArray(fileInfo.PhysicalPath);
    
                string contentStringFace = string.Empty;
                using (ByteArrayContent content = new ByteArrayContent(byteData))
                {
                    // This example uses content type "application/octet-stream".
                    // The other content types you can use are "application/json" and "multipart/form-data".
                    content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
    
                    // Execute the REST API call.
                    var response = client.PostAsync(uri, content).Result;
    
                    // Get the JSON response.
                    contentStringFace = response.Content.ReadAsStringAsync().Result;
                }
    
                if (env.IsDevelopment())
                {
                    app.UseDeveloperExceptionPage();
                }
    
    
                /// <summary>
                /// Returns the contents of the specified file as a byte array.
                /// </summary>
                /// <param name="imageFilePath">The image file to read.</param>
                /// <returns>The byte array of the image data.</returns>
                static byte[] GetImageAsByteArray(string imageFilePath)
                {
                    FileStream fileStream = new FileStream(imageFilePath, FileMode.Open, FileAccess.Read);
                    BinaryReader binaryReader = new BinaryReader(fileStream);
                    return binaryReader.ReadBytes((int)fileStream.Length);
                }
    
                /// <summary>
                /// Formats the given JSON string by adding line breaks and indents.
                /// </summary>
                /// <param name="json">The raw JSON string to format.</param>
                /// <returns>The formatted JSON string.</returns>
                static string JsonPrettyPrint(string json)
                {
                    if (string.IsNullOrEmpty(json))
                        return string.Empty;
    
                    json = json.Replace(Environment.NewLine, "").Replace("\t", "");
    
                    string INDENT_STRING = "    ";
                    var indent = 0;
                    var quoted = false;
                    var sb = new StringBuilder();
                    for (var i = 0; i < json.Length; i++)
                    {
                        var ch = json[i];
                        switch (ch)
                        {
                            case '{':
                            case '[':
                                sb.Append(ch);
                                if (!quoted)
                                {
                                    sb.AppendLine();
                                }
                                break;
                            case '}':
                            case ']':
                                if (!quoted)
                                {
                                    sb.AppendLine();
                                }
                                sb.Append(ch);
                                break;
                            case '"':
                                sb.Append(ch);
                                bool escaped = false;
                                var index = i;
                                while (index > 0 && json[--index] == '\\')
                                    escaped = !escaped;
                                if (!escaped)
                                    quoted = !quoted;
                                break;
                            case ',':
                                sb.Append(ch);
                                if (!quoted)
                                {
                                    sb.AppendLine();
                                }
                                break;
                            case ':':
                                sb.Append(ch);
                                if (!quoted)
                                    sb.Append(" ");
                                break;
                            default:
                                sb.Append(ch);
                                break;
                        }
                    }
                    return sb.ToString();
                }
    
                app.Run(async (context) =>
                {
                    await context.Response.WriteAsync($"<p><b>Face Image:</b></p>");
                    await context.Response.WriteAsync($"<div><img src=\"" + imagePath + "\" /></div>");
                    await context.Response.WriteAsync($"<p><b>Face detection API results:</b></p>");
                    await context.Response.WriteAsync("<p>");
                    await context.Response.WriteAsync(JsonPrettyPrint(contentStringFace));
                    await context.Response.WriteAsync("<p>");
                });
    
            }
        }
    }
