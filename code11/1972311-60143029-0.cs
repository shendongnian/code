    using (StreamReader apacheModRewriteStreamReader =
                    File.OpenText("ApacheModRewrite.txt"))
                using (StreamReader iisUrlRewriteStreamReader =
                    File.OpenText("IISUrlRewrite.xml"))
                {
                    var options = new RewriteOptions()
                        .AddRedirect("redirect-rule/(.*)", "redirected/$1")
                        .AddRewrite(@"^rewrite-rule/(\d+)/(\d+)", "rewritten?var1=$1&var2=$2", skipRemainingRules: true)
                        .AddRewrite(@"customer(\d+)\/(.*)$", "$2?customerid=$1", skipRemainingRules: true)
                        .AddApacheModRewrite(apacheModRewriteStreamReader)
                        .AddIISUrlRewrite(iisUrlRewriteStreamReader)
                        .Add(RewriteRules.MethodRules.RedirectXmlFileRequests)
                        .Add(RewriteRules.MethodRules.RewriteTextFileRequests)
                        .Add(new RewriteRules.RedirectImageRequests(".png", "/png-images"))
                        .Add(new RewriteRules.RedirectImageRequests(".jpg", "/jpg-images"));
    
                    app.UseRewriter(options);
                }
