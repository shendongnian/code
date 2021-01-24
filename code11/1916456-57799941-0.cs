 c#
public Stream CreateReadStream()
        {
            if (_text == null)
            {
                using (var scope = _container.BeginLifetimeScope())
                {
                    var tenantBrandingService = scope.Resolve<ITenantBrandingService>();
                    var settings = tenantBrandingService.Get();
                    using (var stream = _realFile.CreateReadStream())
                    {
                        using (var memoryStream = new MemoryStream())
                        {
                            stream.CopyTo(memoryStream);
                            _text = Encoding.UTF8.GetString(memoryStream.ToArray())
                            .Replace("##mainColor##", settings.MainColor)
                            .Replace("##mainColorText##", settings.MainColorText);                      
                        }
                    }
                }
            }
            return new MemoryStream(Encoding.UTF8.GetBytes(_text));
        }
I used the custom `IFileProvider` in the `app.UseStaticFiles` and in the `app.UseSpa`
