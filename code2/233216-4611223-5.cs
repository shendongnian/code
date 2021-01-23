        ''# fix SO code coloring issue.
        <Extension()>
        Public Function reCaptcha(ByVal htmlHelper As HtmlHelper) As MvcHtmlString
            Dim captchaControl = New Recaptcha.RecaptchaControl With {.ID = "recaptcha",
                                                                      .Theme = "clean",
                                                                      .PublicKey = "XXXXXX",
                                                                      .PrivateKey = "XXXXXX"}
            Dim htmlWriter = New HtmlTextWriter(New IO.StringWriter)
            captchaControl.RenderControl(htmlWriter)
            Return MvcHtmlString.Create(htmlWriter.InnerWriter.ToString)
        End Function
