c#
services.AddMvc(options =>
{
    options.RespectBrowserAcceptHeader = true; // false by default
    .OutputFormatters.Insert(0, new XmlSerializerOutputFormatter());
    options.FormatterMappings.SetMediaTypeMappingForFormat("xml", MediaTypeHeaderValue.Parse("application/xml"));
});
Or you can match the response type based on a format argument in the request path;
c#
        [Route("{id}.{format}"), FormatFilter]
        public async Task<IActionResult> Load(int id)
